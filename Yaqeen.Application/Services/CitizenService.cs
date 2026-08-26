using Yaqeen.Application.DTOs;
using Yaqeen.Application.Interfaces;

namespace Yaqeen.Application.Services;

public class CitizenService : ICitizenService
{
    private readonly ICitizenRepository _citizenRepository;

    public CitizenService(ICitizenRepository citizenRepository)
    {
        _citizenRepository = citizenRepository;
    }

    public async Task<bool> ValidateCitizen(
        CitizenValidationRequest request,
        CancellationToken cancellationToken)
    {
        var citizen = await _citizenRepository
            .GetByNationalIdAndDateOfBirthAsync(
                request.NationalId,
                request.DateOfBirth,
                cancellationToken);

        return citizen is not null;
    }
}