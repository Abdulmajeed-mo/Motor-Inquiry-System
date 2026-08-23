using Microsoft.AspNetCore.Mvc;
using Motor.Inquiry.Common.Responses;
using Yaqeen.Application.Interfaces;
using Yaqeen.Domain.Entities;

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


        [HttpGet("sequence/{sequenceNumber}")]
        public async Task<IActionResult> GetVehicleBySequenceNumber(int sequenceNumber,CancellationToken cancellationToken)
        {
            var vehicle = await _vehicleService.GetVehicleBySequenceNumberAsync(sequenceNumber,cancellationToken);

            if (vehicle == null) return NotFound();

            return Ok(new ApiResponse<Vehicle>
            {
                Success = true,
                Message = "Citizen is valid.",
                Data = vehicle
            });
        }



        [HttpGet("plate")]
        public async Task<IActionResult> GetVehicleByPlate(string plateNumber,string plateLetters,CancellationToken cancellationToken)
        {
            var vehicle = await _vehicleService.GetVehicleByPlateAsync(plateNumber,plateLetters,cancellationToken);

            if (vehicle == null)
                return NotFound();

            return Ok(new ApiResponse<Vehicle>
            {
                Success = true,
                Message = "Citizen is valid.",
                Data = vehicle
            });
        }



    }
}
