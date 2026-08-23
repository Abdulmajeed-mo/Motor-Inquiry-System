using Microsoft.AspNetCore.Mvc;
using Yaqeen.Application.Interfaces;
using Yaqeen.Application.DTOs;
using Motor.Inquiry.Common.Responses;


namespace Yaqeen.API.Controllers
{

    [ApiController]
    [Route("api/yaqeen/citizen")]
    public class CitizenController : ControllerBase
    {

        //private Field
        private readonly ICitizenService _citizenService;
        //Constructor
        public CitizenController(ICitizenService citizenService)
        {
            _citizenService = citizenService;
        }



        //Actions(Endpoints)
        [HttpPost("validate")]
        public IActionResult ValidateCitizen([FromBody] CitizenValidationRequest request, CancellationToken cancellationToken)
        {
          var isValid = _citizenService.ValidateCitizen(request, cancellationToken);
           
            
            if (!isValid)
            {
                return BadRequest(new ApiResponse<bool>
                {
                    Success = false,
                    Message = "Invalid national ID.",
                    Data = false
                });
            }


            return Ok(new ApiResponse<bool>
            {
                Success = true,
                Message = "Citizen is valid.",
                Data = true
            });
        }

    }
}
