using Motor.Inquiry.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Motor.Inquiry.Application.DTOs;


namespace Motor.Inquiry.Application.Services
{
    public class InquiryService : IInquiryService
    {
        //حقن الانترفيس مع سيرفس الانكويري 
        private readonly IYaqeenHttpClient _yaqeenHttpClient;

        public InquiryService(IYaqeenHttpClient yaqeenHttpClient)
        {
            _yaqeenHttpClient = yaqeenHttpClient;
        }


        public  async Task<InquiryResponse> GetInquiryByPlateNumber(InquiryByPlateRequest request)
        {
            var citizenRequest = new CitizenValidationRequest
            {
                NationalId = request.NationalId,
                DateOfBirth = request.DateOfBirth
            };

            var isCitizenValid = await _yaqeenHttpClient.ValidateCitizenAsync(citizenRequest);

            if (!isCitizenValid)
            {
                throw new Exception("Invalid citizen.");
            }
            var vehicle = await _yaqeenHttpClient.GetVehicleByPlateAsync( request.PlateNumber,request.PlateLetters);
            return vehicle;

        }    
                
                

        public async Task<InquiryResponse> GetInquiryBySequenceNumber(InquiryBySequenceRequest request)
        {
            var citizenRequest = new CitizenValidationRequest
            {
                NationalId = request.NationalId,
                DateOfBirth = request.DateOfBirth
            };

            var isCitizenValid = await _yaqeenHttpClient.ValidateCitizenAsync(citizenRequest);

            if (!isCitizenValid)
            {
                throw new Exception("Invalid citizen.");
            }
            var vehicle = await _yaqeenHttpClient.GetVehicleBySequenceAsync(request.SequenceNumber);

            return vehicle;
        }
    }
}