using Microsoft.EntityFrameworkCore;
using Yaqeen.Application.Interfaces;
using Yaqeen.Application.Interfaces.Repositories;
using Yaqeen.Domain.Entities;
using Yaqeen.Infrastructure.Data.Context;

namespace Yaqeen.Infrastructure.Repositories;

public class MakeRepository : IMakeRepository
{
    private readonly YaqeenDbContext _context;

    public MakeRepository(YaqeenDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<Make>> GetAllAsync()
    {
        return await _context.Makes
            .AsNoTracking()
            .ToListAsync();
    }
}