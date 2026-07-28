using Microsoft.AspNetCore.Mvc;
using Yaqeen.Domain.Entities;
using Yaqeen.Application.Interfaces;

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
        public IActionResult ValidateCitizen([FromBody] string nationalId)
        {
          var isValid = _citizenService.ValidateCitizen(nationalId);
           
            
            if (!isValid)
            {
                return BadRequest("Invalid national ID.");
            }




            return Ok("Citizen is valid.");

        }

    }
}
