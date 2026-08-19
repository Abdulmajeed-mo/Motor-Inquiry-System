using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Motor.Inquiry.Application.DTOs;
using Motor.Inquiry.Application.Interfaces;

namespace Motor.Inquiry.API.Controllers
{

    //يستقبل الطلب ويستدعي الـ Service
    

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

        //search by sequence number
        [HttpPost("sequence")]
        public async Task<IActionResult> InquiryBySequenceNumber([FromBody] InquiryBySequenceRequest request, CancellationToken cancellationToken)
        {
            var result = await _inquiryService.GetInquiryBySequenceNumber(request ,cancellationToken);

            return Ok(new ApiResponse<InquiryResponse>
            {
                Success = true,
                Message = "Inquiry completed successfully.",
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
                Message = "Inquiry completed successfully.",
                Data = result
            });
        }

    }
}
