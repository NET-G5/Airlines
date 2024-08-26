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

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NCaF5cXmZCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdnWXdccnRSRWJeWER0VkI=");

builder.Services.AddDbContext<AirlineDbContext>(options =>
    options.UseSqlServer(ConfigurationDefaults.ConectionString));
builder.Services.AddScoped<ICommonRepository, CommonRepository>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserStore, UserStore>();

builder.Services.AddScoped<IFlightRepository, FlightRepository>();
builder.Services.AddScoped<IFlightStore, FlightStore>();

builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IBookingStore, BookingStore>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();