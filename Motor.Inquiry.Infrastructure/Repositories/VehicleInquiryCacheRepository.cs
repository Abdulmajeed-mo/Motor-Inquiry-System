using Microsoft.EntityFrameworkCore;
using Motor.Inquiry.Application.Interfaces;
using Motor.Inquiry.Domain.Entities;
using Motor.Inquiry.Infrastructure.Data.Context;

namespace Motor.Inquiry.Infrastructure.Repositories;

public class VehicleInquiryCacheRepository : IVehicleInquiryCacheRepository
{
    private readonly MotorDbContext _context;

    public VehicleInquiryCacheRepository(MotorDbContext context)
    {
        _context = context;
    }

    public async Task<VehicleInquiryCache?> GetByCacheKeyAsync(string cacheKey,CancellationToken cancellationToken)
    {
        return await _context.VehicleInquiryCaches.FirstOrDefaultAsync(x => x.CacheKey == cacheKey,cancellationToken);
    }

    public async Task AddAsync(VehicleInquiryCache cache,CancellationToken cancellationToken)
    {
        await _context.VehicleInquiryCaches.AddAsync(cache,cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(VehicleInquiryCache cache,CancellationToken cancellationToken)
    {
        _context.VehicleInquiryCaches.Update(cache);

        await _context.SaveChangesAsync(cancellationToken);
    }
}