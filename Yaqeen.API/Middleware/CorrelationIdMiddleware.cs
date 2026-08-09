namespace Yaqeen.API.Middleware;

public class CorrelationIdMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<CorrelationIdMiddleware> _logger;

    public CorrelationIdMiddleware(
        RequestDelegate next,
        ILogger<CorrelationIdMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var correlationId =
            context.Request.Headers["X-Correlation-ID"].FirstOrDefault()
            ?? Guid.NewGuid().ToString();

        _logger.LogInformation(
            "Incoming Request: {Method} {Path} with Correlation ID: {CorrelationId}",
            context.Request.Method,
            context.Request.Path,
            correlationId);

        context.Response.Headers["X-Correlation-ID"] = correlationId;

        await _next(context);
    }
}