using Airline.Domain.Interfaces;
using Airline.Infrastructure;
using Airline.Infrastructure.Repositories;
using AirlineWeb.Extensions;
using AirlineWeb.Stores;
using AirlineWeb.Stores.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using UserStore = AirlineWeb.Stores.UserStore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AirlineDbContextConnection") ?? throw new InvalidOperationException("Connection string 'AirlineDbContextConnection' not found.");

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NCaF5cXmZCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdnWXdccnRSRWJeWER0VkI=");

builder.Services.AddDbContext<AirlineDbContext>(options =>
    options.UseSqlServer("Server=localhost; Database=AirlineDataBase; User Id=sa; Password=MyP@ssw0rd123; TrustServerCertificate=True;"));

builder.Services.AddScoped<ICommonRepository, CommonRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IFlightRepository, FlightRepository>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();

builder.Services.AddScoped<IUserStore, UserStore>();
builder.Services.AddScoped<IFlightStore, FlightStore>();
builder.Services.AddScoped<IBookingStore, BookingStore>();

builder.Services
    .AddControllers(options =>
    {
        var polisy = new AuthorizationPolicyBuilder()
            .RequireAuthenticatedUser()
            .Build();
        options.Filters.Add(new AuthorizeFilter(polisy));
    }) 
    .AddJsonOptions(x =>
    {
        x.JsonSerializerOptions.PropertyNamingPolicy = null;
    });

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AirlineDbContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.SignIn.RequireConfirmedPhoneNumber = false; 
    
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 8; 

    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    options.User.RequireUniqueEmail = true;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/AccessDenied";
    options.SlidingExpiration = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
} 
else
{
    // Seed the database with initial data
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<AirlineDbContext>();
    DatabaseInitializer.GenerateAllData(context);
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Flight}/{action=Index}/{id?}");

app.Run();