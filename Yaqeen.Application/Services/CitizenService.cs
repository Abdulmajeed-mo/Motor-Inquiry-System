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

    public async Task<bool> ValidateCitizen(CitizenValidationRequest request,CancellationToken cancellationToken)
    {
        var citizen = await _citizenRepository
            .GetByNationalIdAndDateOfBirthAsync(
                request.NationalId,
                request.DateOfBirth,
                cancellationToken);

        return citizen is not null;
    }




    //يطلب البيانات من الـ Repository.
    public async Task<CitizenAddressResponse?> GetCitizenWithAddressesAsync(string nationalId,CancellationToken cancellationToken)
    {
        var citizen = await _citizenRepository.GetCitizenWithAddressesAsync(nationalId,cancellationToken);

        if (citizen is null)
         
            return null;


        return new CitizenAddressResponse
        {
            NationalId = citizen.NationalId,
            FullName = citizen.FullName,
            Addresses = citizen.Addresses.Select(a => a.AddressLine).ToList()
        };
    }
}

//Repository → يرجع Entity

//⬇️

//Service → يحوّل Entity إلى DTO

//⬇️

//Controller → يرجع DTO للـ Client