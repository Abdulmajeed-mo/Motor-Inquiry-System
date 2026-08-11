using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Motor.Inquiry.Application.DTOs;
using Motor.Inquiry.Application.Interfaces;

namespace Motor.Inquiry.API.Controllers
{

    [ApiController]
    [ApiVersion(1.0)]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class InquiryController : ControllerBase
    {

        //private field
        private readonly IInquiryService _inquiryService;



        //Constructor
        public InquiryController(IInquiryService inquiryService)
        {
            _inquiryService = inquiryService;
        }


        //Action Methods
        [HttpPost("sequence")]
        public async Task<IActionResult> InquiryBySequenceNumber([FromBody] InquiryBySequenceRequest request)
        {
            var result = await _inquiryService.GetInquiryBySequenceNumber(request);

            return Ok(new ApiResponse<InquiryResponse>
            {
                Success = true,


                Message = "Inquiry completed successfully.",
                Data = result
            });
        }


        [HttpPost("plate")]
        public async Task<IActionResult> InquiryByPlateNumber([FromBody] InquiryByPlateRequest request)
        {
            var result = await _inquiryService.GetInquiryByPlateNumber(request);
           
            return Ok(new ApiResponse<InquiryResponse>
            {
                Success = true,
                Message = "Inquiry completed successfully.",
                Data = result
            });
        }

    }
}
