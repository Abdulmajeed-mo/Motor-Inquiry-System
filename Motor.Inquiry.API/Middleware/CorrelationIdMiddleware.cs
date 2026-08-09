namespace Motor.Inquiry.API.Middleware;

public class CorrelationIdMiddleware
{
    //private field
    private readonly RequestDelegate _next;
    private readonly ILogger<CorrelationIdMiddleware> _logger;

    //constructor
    public CorrelationIdMiddleware(RequestDelegate next, ILogger<CorrelationIdMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }
    //Action Method
    public async Task InvokeAsync(HttpContext context)
    {
        var correlationId = Guid.NewGuid().ToString();
        context.Request.Headers["X-Correlation-ID"] = correlationId;


        _logger.LogInformation("Incoming Request: {Method} {Path} with Correlation ID: {CorrelationId}", context.Request.Method, context.Request.Path, correlationId);

        context.Response.Headers["X-Correlation-ID"] = correlationId;
        await _next(context);
    }

}
