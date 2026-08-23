namespace Motor.Inquiry.API.Extensions;

public static class ApiServiceExtensions
{
    public static IServiceCollection AddApiServices(
        this IServiceCollection services)
    {
        services.AddControllers();

        services.AddHealthChecks();

        services.AddApiVersioning();

        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen();

        return services;
    }
}