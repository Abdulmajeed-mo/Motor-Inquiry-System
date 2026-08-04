using Motor.Inquiry.Domain.Exceptions;

namespace Motor.Inquiry.API.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        context.Response.ContentType = "application/json";

        context.Response.StatusCode = ex switch
        {
            InvalidCitizenException => StatusCodes.Status400BadRequest,
            VehicleNotFoundException => StatusCodes.Status404NotFound,
            OwnershipMismatchException => StatusCodes.Status403Forbidden,
            _ => StatusCodes.Status500InternalServerError
        };

        var response = new
        {
            message = ex.Message
        };

        await context.Response.WriteAsJsonAsync(response);
    }
}