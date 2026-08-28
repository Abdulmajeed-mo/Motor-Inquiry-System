using Microsoft.EntityFrameworkCore;
using Yaqeen.Application.Interfaces;
using Yaqeen.Application.Interfaces.Repositories;
using Yaqeen.Domain.Entities;
using Yaqeen.Infrastructure.Data.Context;

namespace Yaqeen.Infrastructure.Repositories;

public class ModelRepository : IModelRepository
{
    private readonly YaqeenDbContext _context;

    public ModelRepository(YaqeenDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<Model>> GetAllAsync()
    {
        return await _context.Models
            .AsNoTracking()
            .ToListAsync();
    }
}