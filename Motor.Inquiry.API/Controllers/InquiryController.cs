using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Motor.Inquiry.Application.DTOs;
using Motor.Inquiry.Application.Interfaces;
using Motor.Inquiry.Common.Responses;
using System.Globalization;


namespace Motor.Inquiry.API.Controllers
{

    //يستقبل الطلب ويستدعي الـ Service

    [Authorize]
    [ApiController]
    [ApiVersion(1.0)]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class InquiryController : ControllerBase
    {

        //private field
        private readonly IInquiryService _inquiryService;

        private readonly IStringLocalizer<InquiryController> _localizer;


        //Constructor
        public InquiryController(IInquiryService inquiryService , IStringLocalizer<InquiryController> localizer)
        {
            _inquiryService = inquiryService;
            _localizer = localizer;
        }


        //Action Methods

        //search by sequence number
        [HttpPost("sequence")]
        public async Task<IActionResult> InquiryBySequenceNumber([FromBody] InquiryBySequenceRequest request, CancellationToken cancellationToken)
        {


            Console.WriteLine($"Current Culture: {CultureInfo.CurrentCulture.Name}");
            Console.WriteLine($"Current UI Culture: {CultureInfo.CurrentUICulture.Name}");


            var result = await _inquiryService.GetInquiryBySequenceNumber(request ,cancellationToken);

            return Ok(new ApiResponse<InquiryResponse>
            {
                Success = true,
                Message = _localizer["InquiryCompletedSuccessfully"] ,
                Data = result
            });
        }


        //search by plate number
        [HttpPost("plate")]
        public async Task<IActionResult> InquiryByPlateNumber([FromBody] InquiryByPlateRequest request, CancellationToken cancellationToken)
        {
            var result = await _inquiryService.GetInquiryByPlateNumber(request,cancellationToken);
           
            return Ok(new ApiResponse<InquiryResponse>
            {
                Success = true,
                Message = _localizer["InquiryCompletedSuccessfully"],
                
               Data = result
            });
        }

        [HttpGet("localization-test")]
        public IActionResult LocalizationTest()
        {
            var test = _localizer["Welcome"];

            return Ok(test);
        }

    }
}
