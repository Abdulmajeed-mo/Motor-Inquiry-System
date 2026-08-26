using Microsoft.EntityFrameworkCore;
using Yaqeen.Application.Interfaces;
using Yaqeen.Domain.Entities;
using Yaqeen.Infrastructure.Data.Context;

namespace Yaqeen.Infrastructure.Repositories;

public class VehicleRepository : IVehicleRepository
{
    private readonly YaqeenDbContext _context;

    public VehicleRepository(YaqeenDbContext context)
    {
        _context = context;
    }

    public async Task<Vehicle?> GetByPlateAsync(string plateNumber,string plateLetters,CancellationToken cancellationToken)
    {
        return await _context.Vehicles.FirstOrDefaultAsync(v => v.PlateNumber == plateNumber &&v.PlateLetters == plateLetters,cancellationToken);
    }

    public async Task<Vehicle?> GetBySequenceNumberAsync(int sequenceNumber,CancellationToken cancellationToken)
    {
        return await _context.Vehicles .FirstOrDefaultAsync(v => v.SequenceNumber == sequenceNumber,cancellationToken);
    }
}