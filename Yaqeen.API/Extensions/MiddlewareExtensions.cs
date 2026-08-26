using Yaqeen.API.Middleware;

namespace Yaqeen.API.Extensions;



// Extension methods for configuring Yaqeen middleware in the HTTP request pipeline.
public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseYaqeenMiddleware(this IApplicationBuilder app)
    {


        // Registers Yaqeen custom middleware components in the application pipeline.
        app.UseMiddleware<CorrelationIdMiddleware>();

        return app;
    }
}