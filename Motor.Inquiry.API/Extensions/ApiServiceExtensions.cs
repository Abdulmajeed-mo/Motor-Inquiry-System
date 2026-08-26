using Microsoft.AspNetCore.Localization;
using Motor.Inquiry.API.Resources;
using System.Globalization;

namespace Motor.Inquiry.API.Extensions;

public static class ApiServiceExtensions
{

    // Registers API services such as controllers, health checks, API versioning, and Swagger.
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {

        // Add localization services
        services.AddLocalization(options =>{options.ResourcesPath = "Resources";});


        services.Configure<RequestLocalizationOptions>(options =>
        {
            options.DefaultRequestCulture = new RequestCulture(SharedResourceMarker.DefaultCulture);
            options.SupportedCultures = SharedResourceMarker.SupportedCultures;
            options.SupportedUICultures = SharedResourceMarker.SupportedCultures;
        });


        services.AddControllers().AddDataAnnotationsLocalization(options => { options.DataAnnotationLocalizerProvider = (type, factory) => factory.Create(typeof(SharedResourceMarker)); });


        services.AddHealthChecks();

        services.AddApiVersioning();

        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen();

        return services;
    }
}
