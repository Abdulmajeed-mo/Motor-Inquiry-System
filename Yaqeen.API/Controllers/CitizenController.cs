using Microsoft.AspNetCore.Mvc;
using Yaqeen.Application.Interfaces;
using Yaqeen.Application.DTOs;
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
        public IActionResult ValidateCitizen([FromBody] CitizenValidationRequest request)
        {
          var isValid = _citizenService.ValidateCitizen(request);
           
            
            if (!isValid)
            {
                return BadRequest("Invalid national ID.");
            }




            return Ok("Citizen is valid.");

        }

    }
}
