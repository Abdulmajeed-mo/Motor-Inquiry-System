using Yaqeen.Domain.Entities;

namespace Yaqeen.Application.Interfaces;

public interface ICitizenRepository
{
    Task<Citizen?> GetByNationalIdAndDateOfBirthAsync(
        string nationalId,
        DateOnly dateOfBirth,
        CancellationToken cancellationToken);
}