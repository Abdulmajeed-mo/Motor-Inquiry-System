using Motor.Inquiry.Application.DTOs;

namespace Motor.Inquiry.Application.Interfaces
{
    public interface IYaqeenHttpClient
    {

        Task<bool> ValidateCitizenAsync(CitizenValidationRequest request);
        Task<VehicleInquiryDto> GetVehicleBySequenceAsync(int sequenceNumber);
        Task<VehicleInquiryDto> GetVehicleByPlateAsync(string plateNumber,string plateLetters);
    }
}
