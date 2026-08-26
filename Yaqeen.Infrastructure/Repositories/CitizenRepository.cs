using Microsoft.EntityFrameworkCore;
using Yaqeen.Application.Interfaces;
using Yaqeen.Domain.Entities;
using Yaqeen.Infrastructure.Data.Context;

namespace Yaqeen.Infrastructure.Repositories;

public class CitizenRepository : ICitizenRepository
{
    private readonly YaqeenDbContext _context;

    public CitizenRepository(YaqeenDbContext context)
    {
        _context = context;
    }

    public async Task<Citizen?> GetByNationalIdAndDateOfBirthAsync(string nationalId,DateOnly dateOfBirth,CancellationToken cancellationToken)
    {
        return await _context.Citizens.FirstOrDefaultAsync(c => c.NationalId == nationalId && c.DateOfBirth == dateOfBirth,cancellationToken);
    }
}

