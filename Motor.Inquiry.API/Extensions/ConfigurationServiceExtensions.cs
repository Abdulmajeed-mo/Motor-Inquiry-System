using Motor.Inquiry.API.Configuration;
using Motor.Inquiry.Infrastructure.Configuration;

namespace Motor.Inquiry.API.Extensions;


//Register Strongly Typed Options Only
public static class ConfigurationServiceExtensions
{

    // Registers strongly typed configuration settings using the Options Pattern.
    public static IServiceCollection AddConfigurationServices(this IServiceCollection services,IConfiguration configuration)
    {
        services.Configure<YaqeenApiOptions>(configuration.GetSection(YaqeenApiOptions.SectionName));

        services.Configure<CacheSettingsOptions>(configuration.GetSection(CacheSettingsOptions.SectionName));

        services.Configure<RateLimitOptions>(configuration.GetSection(RateLimitOptions.SectionName));

        return services;
    }
}