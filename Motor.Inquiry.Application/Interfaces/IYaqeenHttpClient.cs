using Motor.Inquiry.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motor.Inquiry.Application.Interfaces
{
    public interface IYaqeenHttpClient
    {

        Task<bool> ValidateCitizenAsync(CitizenValidationRequest request);
        Task<InquiryResponse> GetVehicleBySequenceAsync(int sequenceNumber);
        Task<InquiryResponse> GetVehicleByPlateAsync(string plateNumber,string plateLetters);
    }
}
