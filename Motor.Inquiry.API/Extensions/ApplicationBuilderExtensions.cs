//Pipeline configuration not Service registration.
//Middleware Extension
using Motor.Inquiry.API.Middleware;

namespace Motor.Inquiry.API.Extensions;

public static class ApplicationBuilderExtensions
{

    // Configures the HTTP request pipeline, including middleware, security, Swagger, and endpoint mapping.
    public static WebApplication UseApplicationPipeline(this WebApplication app)
    {
        app.UseMiddleware<ExceptionMiddleware>();

        app.UseRateLimiter();

        app.UseMiddleware<CorrelationIdMiddleware>();

        if (app.Environment.IsDevelopment() ||
            app.Environment.IsStaging())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.MapHealthChecks("/health");

        return app;
    }
}