namespace Motor.Inquiry.API.Extensions;

public static class ApiServiceExtensions
{

    // Registers API services such as controllers, health checks, API versioning, and Swagger.
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddControllers();

        services.AddHealthChecks();

        services.AddApiVersioning();

        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen();

        return services;
    }
}