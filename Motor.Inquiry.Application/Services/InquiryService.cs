using Motor.Inquiry.Application.DTOs;
using Motor.Inquiry.Application.Interfaces;
using Motor.Inquiry.Domain.Entities;
using Motor.Inquiry.Domain.Exceptions;


namespace Motor.Inquiry.Application.Services
{
    public class InquiryService : IInquiryService
    {
        //حقن الانترفيس مع سيرفس الانكويري 
        private readonly IYaqeenHttpClient _yaqeenHttpClient;

        private readonly IInquiryHistoryWriter _inquiryHistoryWriter;

        public InquiryService(IYaqeenHttpClient yaqeenHttpClient, IInquiryHistoryWriter inquiryHistoryWriter)
        {
            _yaqeenHttpClient = yaqeenHttpClient;
            _inquiryHistoryWriter = inquiryHistoryWriter;
            }


        public async Task<InquiryResponse> GetInquiryByPlateNumber(InquiryByPlateRequest request)
        {
            var citizenRequest = new CitizenValidationRequest
            {
                NationalId = request.NationalId,
                DateOfBirth = request.DateOfBirth
            };

            var isCitizenValid = await _yaqeenHttpClient.ValidateCitizenAsync(citizenRequest);

            if (!isCitizenValid)
            {
                throw new InvalidCitizenException("Invalid citizen.");
            }
            var vehicle = await _yaqeenHttpClient.GetVehicleByPlateAsync(request.PlateNumber, request.PlateLetters);



            if (vehicle.OwnerNationalId != request.NationalId)
            {
                throw new OwnershipMismatchException("Vehicle ownership mismatch.");
            }


            await _inquiryHistoryWriter.WriteAsync(new InquiryHistory
            {
                NationalId = request.NationalId,
                InquiryType = "Plate",
                PlateNumber = vehicle.PlateNumber,
                PlateLetters = vehicle.PlateLetters,
                CreatedAt = DateTime.UtcNow
            });
            return new InquiryResponse
            {
                SequenceNumber = vehicle.SequenceNumber,
                PlateNumber = vehicle.PlateNumber,
                PlateLetters = vehicle.PlateLetters,
                Make = vehicle.Make,
                Model = vehicle.Model,
                ModelYear = vehicle.ModelYear,
                Color = vehicle.Color,
                ChassisNumber = vehicle.ChassisNumber
            };
        }



        public async Task<InquiryResponse> GetInquiryBySequenceNumber(InquiryBySequenceRequest request)
        {
            var citizenRequest = new CitizenValidationRequest {NationalId = request.NationalId, DateOfBirth = request.DateOfBirth };

            var isCitizenValid = await _yaqeenHttpClient.ValidateCitizenAsync(citizenRequest);
            if (!isCitizenValid)
            {
                throw new InvalidCitizenException("Invalid citizen.");
            }

            var vehicle =
                await _yaqeenHttpClient.GetVehicleBySequenceAsync(
                    request.SequenceNumber);

            if (vehicle.OwnerNationalId != request.NationalId)
            {
                throw new OwnershipMismatchException("Vehicle ownership mismatch.");
            }



            await _inquiryHistoryWriter.WriteAsync(new InquiryHistory
            {
                NationalId = request.NationalId,
                InquiryType = "Sequence",
                SequenceNumber = vehicle.SequenceNumber,
                CreatedAt = DateTime.UtcNow
            });



            return new InquiryResponse
            {
                SequenceNumber = vehicle.SequenceNumber,
                PlateNumber = vehicle.PlateNumber,
                PlateLetters = vehicle.PlateLetters,
                Make = vehicle.Make,
                Model = vehicle.Model,
                ModelYear = vehicle.ModelYear,
                Color = vehicle.Color,
                ChassisNumber = vehicle.ChassisNumber
            };
        }
    }
}