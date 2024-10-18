using Airline.Application.Extensions;
using Airline.Infrastructure.Extensions;
using AirlineWeb.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Syncfusion.Licensing;

namespace AirlineWeb.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.RegisterInfrastructure(configuration);
        services.RegisterApplication(configuration);

        AddControllers(services);
        AddProviders(configuration);

        services.ConfigureApplicationCookie(options =>
        {
            options.Cookie.HttpOnly = true;
            options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
            options.LoginPath = "/Account/Login";
            options.AccessDeniedPath = "/Account/AccessDenied";
            options.SlidingExpiration = true;
        });

        services.AddHttpContextAccessor();

        return services;
    }

    private static void AddControllers(this IServiceCollection services)
    {
        services
            .AddControllersWithViews()
            .AddRazorRuntimeCompilation();

        services
            .AddControllers(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
                options.Filters.Add(new ExceptionHandlerFilter());
                options.Filters.Add(new HeaderResultFilter());
                options.Filters.Add(new UserRequestFilter());
            })
            .AddJsonOptions(x =>
            {
                x.JsonSerializerOptions.PropertyNamingPolicy = null;
            });
    }

    private static void AddProviders(IConfiguration configuration)
    {
        var syncfusionKey = configuration.GetValue<string>("SyncfusionKey")
            ?? throw new InvalidOperationException("Syncfusion key is not found.");

        SyncfusionLicenseProvider.RegisterLicense(syncfusionKey);
    }
}
