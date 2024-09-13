using Airline.Domain.Interfaces;
using Airline.Infrastructure;
using Airline.Infrastructure.Persistence.Configurations;
using Airline.Infrastructure.Repositories;
using AirlineWeb.Extensions;
using AirlineWeb.Stores;
using AirlineWeb.Stores.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register Syncfusion license
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NCaF5cXmZCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdnWXdccnRSRWJeWER0VkI=");

// Configure database _context
builder.Services.AddDbContext<AirlineDbContext>(options =>
    options.UseSqlServer("Server=localhost; Database=AirlineDataBase; User Id=sa; Password=MyP@ssw0rd123; TrustServerCertificate=True;"));

// Register repositories
builder.Services.AddScoped<ICommonRepository, CommonRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IFlightRepository, FlightRepository>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();

// Register stores
builder.Services.AddScoped<IUserStore, UserStore>();
builder.Services.AddScoped<IFlightStore, FlightStore>();
builder.Services.AddScoped<IBookingStore, BookingStore>();

builder.Services.AddControllersWithViews();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Flight}/{action=Index}/{id?}");

app.Run();