using Microsoft.Extensions.Localization;
using Motor.Inquiry.API.Controllers;
using Motor.Inquiry.Common.Responses;
using Motor.Inquiry.Domain.Exceptions;
using System.Globalization;


namespace Motor.Inquiry.API.Middleware;

public class ExceptionMiddleware
{
    //private field
    private readonly IStringLocalizer<InquiryController> _localizer;
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    //constructor
    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger , IStringLocalizer<InquiryController> localizer )
    {
        _next = next;
        _logger = logger;
        _localizer = localizer;
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
    private  async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        context.Response.ContentType = "application/json";

        context.Response.StatusCode = ex switch
        {
            InvalidCitizenException => StatusCodes.Status400BadRequest,
            VehicleNotFoundException => StatusCodes.Status404NotFound,


            OwnershipMismatchException => StatusCodes.Status403Forbidden,
            
            _ => StatusCodes.Status500InternalServerError
        };


    
        _logger.LogInformation("Localization: {Culture}, Key: {Key}, Value: {Value}",CultureInfo.CurrentUICulture.Name,"OwnershipMismatch",_localizer["OwnershipMismatch"].Value);

        //يكشف تفاصيل داخلية للـ Client.
        var message = ex switch
        {
            InvalidCitizenException => _localizer["InvalidCitizen"],
            VehicleNotFoundException => _localizer["VehicleNotFound"],
            OwnershipMismatchException => _localizer["OwnershipMismatch"],
            _ => _localizer["UnexpectedError"]
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