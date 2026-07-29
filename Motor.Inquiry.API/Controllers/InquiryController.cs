using Microsoft.AspNetCore.Mvc;
using Motor.Inquiry.Application.DTOs;
using Motor.Inquiry.Application.Interfaces;

namespace Motor.Inquiry.API.Controllers
{


    [ApiController]
    [Route("api/[controller]")]

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
        public IActionResult InquiryBySequenceNumber([FromBody] InquiryBySequenceRequest request)
        {
            var result = _inquiryService.GetInquiryBySequenceNumber(request);

            return Ok(result);
        }


        [HttpPost("plate")]
        public IActionResult InquiryByPlateNumber([FromBody] InquiryByPlateRequest request)
        {
            var result = _inquiryService.GetInquiryByPlateNumber(request);
            return Ok(result);
        }

    }
}
