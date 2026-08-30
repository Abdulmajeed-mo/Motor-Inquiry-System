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
        public async Task<IActionResult> ValidateCitizen([FromBody] CitizenValidationRequest request, CancellationToken cancellationToken)
        {
          var isValid = await _citizenService.ValidateCitizen(request, cancellationToken);
           
            
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





        [HttpGet("{nationalId}/addresses")]
        public async Task<IActionResult> GetCitizenAddresses(string nationalId,CancellationToken cancellationToken)
        {
            var result = await _citizenService.GetCitizenWithAddressesAsync(nationalId,cancellationToken);

            if (result is null)
            {
                return NotFound(new ApiResponse<CitizenAddressResponse>
                {
                    Success = false,
                    Message = "Citizen not found.",
                    Data = null
                });
            }
            



            return Ok(new ApiResponse<CitizenAddressResponse>
            {
                Success = true,
                Message = "Citizen addresses retrieved successfully.",
                Data = result
            });
        }

    }
}
