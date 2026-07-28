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
        public Vehicle GetVehicleByPlate(string plateNumber, string plateLetters)
        {
            var ByPlate = MockData.Vehicles.FirstOrDefault(v => v.PlateNumber == plateNumber && v.PlateLetters == plateLetters);
            return ByPlate;
        }
        public Vehicle GetVehicleBySequenceNumber(int sequenceNumber)
        {

            var BySequenceNumber = MockData.Vehicles.FirstOrDefault(v => v.SequenceNumber == sequenceNumber);
            return BySequenceNumber;
        }
    }
}
