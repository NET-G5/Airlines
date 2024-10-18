using Airline.Application.Services;
using Airline.Application.Services.Interfaces;
using Airline.Application.Stores;
using Airline.Application.Stores.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Airline.Application.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection RegisterApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUserStore, UserStore>();
        services.AddScoped<IFlightStore, FlightStore>();
        services.AddScoped<IBookingStore, BookingStore>();
        services.AddScoped<ICurrentUserService, CurrentUserService>();

        return services;
    }
}