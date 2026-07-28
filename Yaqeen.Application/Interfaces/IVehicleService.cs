using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yaqeen.Domain.Entities;

namespace Yaqeen.Application.Interfaces
{
    public interface IVehicleService
    {
        Vehicle GetVehicleByPlate(string plateNumber , string plateLetters);

        Vehicle GetVehicleBySequenceNumber(int sequenceNumber);
    }
}
