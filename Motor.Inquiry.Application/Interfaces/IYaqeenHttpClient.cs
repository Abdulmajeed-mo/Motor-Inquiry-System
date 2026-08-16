using Motor.Inquiry.Application.DTOs;

namespace Motor.Inquiry.Application.Interfaces
{
    public interface IYaqeenHttpClient
    {

        Task<bool> ValidateCitizenAsync(CitizenValidationRequest request, CancellationToken cancellationToken);
        Task<VehicleInquiryDto> GetVehicleBySequenceAsync(int sequenceNumber, CancellationToken cancellationToken);
        Task<VehicleInquiryDto> GetVehicleByPlateAsync(string plateNumber,string plateLetters, CancellationToken cancellationToken);
    }
}
