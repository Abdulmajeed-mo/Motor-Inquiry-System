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
        Task<Vehicle?> GetVehicleByPlateAsync(string plateNumber,string plateLetters,CancellationToken cancellationToken);

        Task<Vehicle?> GetVehicleBySequenceNumberAsync(int sequenceNumber,CancellationToken cancellationToken);
    }
}
