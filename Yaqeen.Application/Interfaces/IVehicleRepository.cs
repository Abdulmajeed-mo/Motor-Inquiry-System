using Yaqeen.Domain.Entities;

namespace Yaqeen.Application.Interfaces;

public interface IVehicleRepository
{
    Task<Vehicle?> GetByPlateAsync(
        string plateNumber,
        string plateLetters,
        CancellationToken cancellationToken);



    Task<Vehicle?> GetBySequenceNumberAsync(
        int sequenceNumber,
        CancellationToken cancellationToken);
}