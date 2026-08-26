using Motor.Inquiry.Domain.Entities;

namespace Motor.Inquiry.Application.Interfaces;

public interface IVehicleInquiryCacheRepository
{
    Task<VehicleInquiryCache?> GetByCacheKeyAsync(string cacheKey,CancellationToken cancellationToken);

    Task AddAsync(VehicleInquiryCache cache,CancellationToken cancellationToken);

    Task UpdateAsync(VehicleInquiryCache cache,CancellationToken cancellationToken);
}