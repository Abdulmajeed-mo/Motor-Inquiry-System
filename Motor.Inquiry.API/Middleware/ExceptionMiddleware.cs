using Motor.Inquiry.Domain.Exceptions;
using Motor.Inquiry.Application.DTOs;

namespace Motor.Inquiry.API.Middleware;

public class ExceptionMiddleware
{
    //private field
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    //constructor
    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }


    //Action Method
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            _logger.LogInformation("Incoming Request: {Method} {Path}", context.Request.Method, context.Request.Path);

            await _next(context);
        }

        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception on {Path}: {Message}", context.Request.Path , ex.Message);

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

        var response = new ApiResponse<object>
        {
            Success = false,

            Message = ex.Message,
            Data = null
        };

        await context.Response.WriteAsJsonAsync(response);
    }
}