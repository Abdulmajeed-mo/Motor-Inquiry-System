using Microsoft.AspNetCore.Mvc;
using Yaqeen.Application.Interfaces;

namespace Yaqeen.API.Controllers
{


    [ApiController]
    [Route("api/yaqeen/vehicle")]
    public class VehicleController : ControllerBase
    {
        //private Field
        private readonly IVehicleService _vehicleService;
        //Constructor
        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }


        //Actions(Endpoints)
        [HttpGet("sequence/{sequenceNumber}")]
        public IActionResult GetVehicleBySequenceNumber(int sequenceNumber)
        {
            var vehicle = _vehicleService.GetVehicleBySequenceNumber(sequenceNumber);
            if (vehicle == null)
            {
                return NotFound();
            }
            return Ok(vehicle);
        }

        [HttpGet("plate")]
        public IActionResult GetVehicleByPlate(string plateNumber, string plateLetters)
        {
            var vehicle = _vehicleService.GetVehicleByPlate(plateNumber, plateLetters);
            if (vehicle == null)
            {
                return NotFound();
            }
            return Ok(vehicle);
        }



    }
}
