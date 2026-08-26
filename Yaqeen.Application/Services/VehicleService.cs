using Yaqeen.Application.DTOs;
using Yaqeen.Application.Interfaces;
using Yaqeen.Domain.Entities;

namespace Yaqeen.Application.Services;

public class VehicleService : IVehicleService
{



    private readonly IVehicleRepository _vehicleRepository;



    public VehicleService(IVehicleRepository vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }




    public async Task<Vehicle?> GetVehicleByPlateAsync(string plateNumber,string plateLetters,CancellationToken cancellationToken)
    {
        return await _vehicleRepository.GetByPlateAsync(plateNumber,plateLetters,cancellationToken);
    }




    public async Task<Vehicle?> GetVehicleBySequenceNumberAsync(int sequenceNumber,CancellationToken cancellationToken)
    {
        return await _vehicleRepository.GetBySequenceNumberAsync(sequenceNumber,cancellationToken);
    }
}