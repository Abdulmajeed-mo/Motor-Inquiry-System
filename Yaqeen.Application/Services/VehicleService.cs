using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yaqeen.Domain.Entities;
using Yaqeen.Application.Interfaces;
using Yaqeen.Application.Data;

namespace Yaqeen.Application.Services
{
    public class VehicleService : IVehicleService
    {
        public async Task<Vehicle?> GetVehicleByPlateAsync(string plateNumber,string plateLetters,CancellationToken cancellationToken)
        {
            var vehicle = MockData.Vehicles.FirstOrDefault(v =>v.PlateNumber == plateNumber &&v.PlateLetters == plateLetters);

            return await Task.FromResult(vehicle);
        }

        public async Task<Vehicle?> GetVehicleBySequenceNumberAsync(int sequenceNumber,CancellationToken cancellationToken)
        {
            var vehicle = MockData.Vehicles.FirstOrDefault(v =>v.SequenceNumber == sequenceNumber);

            return await Task.FromResult(vehicle);
        }
    }
}
