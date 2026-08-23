using Motor.Inquiry.Domain.Exceptions;
using Motor.Inquiry.Common.Responses;

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
    //middleware to handle exceptions and return appropriate response
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {

            await _next(context);
        }

        catch (Exception ex)
        {
            //التفاصيل الكاملة للخطأ
            _logger.LogError(ex,"Unhandled exception on {Path}",context.Request.Path);

            if (!context.Response.HasStarted)
            {
                await HandleExceptionAsync(context, ex);
            }
            else
            {
                _logger.LogWarning("The response has already started. The exception response cannot be modified.");
            }
        }
    }



    //private method to handle exceptions and return appropriate response
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


        //يكشف تفاصيل داخلية للـ Client.
        var message = ex switch
        {
            InvalidCitizenException or
            VehicleNotFoundException or
            OwnershipMismatchException => ex.Message,

            _ => "An unexpected error occurred."
        };

        var response = new ApiResponse<object>
        {
            Success = false,
            Message = message,
            Data = null
        };

        await context.Response.WriteAsJsonAsync(response);
    }
}