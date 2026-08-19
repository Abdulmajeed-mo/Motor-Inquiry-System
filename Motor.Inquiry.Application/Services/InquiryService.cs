using Motor.Inquiry.Application.DTOs;
using Motor.Inquiry.Application.Interfaces;
using Motor.Inquiry.Domain.Entities;
using Motor.Inquiry.Domain.Exceptions;
using Microsoft.Extensions.Logging;
using AutoMapper;


namespace Motor.Inquiry.Application.Services
{

    //Business logic layer

    public class InquiryService : IInquiryService
    {

        //حقن الانترفيس مع سيرفس الانكويري 
        //private field
        private readonly ILogger<InquiryService> _logger;
        private readonly IYaqeenHttpClient _yaqeenHttpClient;
        private readonly IInquiryHistoryWriter _inquiryHistoryWriter;
        private readonly IMapper _mapper;


        //constructor
        public InquiryService(IYaqeenHttpClient yaqeenHttpClient, IInquiryHistoryWriter inquiryHistoryWriter, ILogger<InquiryService> logger, IMapper mapper)
        {
            _yaqeenHttpClient = yaqeenHttpClient;
            _inquiryHistoryWriter = inquiryHistoryWriter;
            _logger = logger;
            _mapper = mapper;
        }


        //Action Method

        //search by plate number
        public async Task<InquiryResponse> GetInquiryByPlateNumber(InquiryByPlateRequest request, CancellationToken cancellationToken)
        {
            //citizen Validate
            var citizenRequest = new CitizenValidationRequest {NationalId = request.NationalId,DateOfBirth = request.DateOfBirth};

            var isCitizenValid = await _yaqeenHttpClient.ValidateCitizenAsync(citizenRequest, cancellationToken);

            if (!isCitizenValid)
            {
                throw new InvalidCitizenException("Invalid citizen.");
            }
            var vehicle = await _yaqeenHttpClient.GetVehicleByPlateAsync(request.PlateNumber, request.PlateLetters, cancellationToken);


            //يتأكد من الملكية
            if (vehicle.OwnerNationalId != request.NationalId)
            {
                throw new OwnershipMismatchException("Vehicle ownership mismatch.");
            }

            //automapper to map the vehicle entity to InquiryResponse DTO
            //يسجلها في InquiryHistory
            //convert the InquiryHistory entity to a DTO and write it to the database using the IInquiryHistoryWriter interface
            await _inquiryHistoryWriter.WriteAsync(new InquiryHistory
            {
                NationalId = request.NationalId,
                InquiryType = "Plate",
                PlateNumber = vehicle.PlateNumber,
                PlateLetters = vehicle.PlateLetters,
                CreatedAt = DateTime.UtcNow
            });

            _logger.LogInformation("Inquiry by plate number completed successfully for PlateNumber: {PlateNumber}, PlateLetters: {PlateLetters}",  request.PlateNumber, request.PlateLetters);

            return _mapper.Map<InquiryResponse>(vehicle);
        }


        //search by sequence number
        public async Task<InquiryResponse> GetInquiryBySequenceNumber(InquiryBySequenceRequest request,CancellationToken cancellationToken)
        {
            //citizen Validate

            var citizenRequest = new CitizenValidationRequest {NationalId = request.NationalId, DateOfBirth = request.DateOfBirth };

            var isCitizenValid = await _yaqeenHttpClient.ValidateCitizenAsync(citizenRequest, cancellationToken);
            
            if (!isCitizenValid)
            {
                throw new InvalidCitizenException("Invalid citizen.");
            }

            var vehicle = await _yaqeenHttpClient.GetVehicleBySequenceAsync(request.SequenceNumber , cancellationToken);

            if (vehicle.OwnerNationalId != request.NationalId)
            {
                throw new OwnershipMismatchException("Vehicle ownership mismatch.");
            }


            //automapper to map the vehicle entity to InquiryResponse DTO
            //يسجلها في InquiryHistory
            await _inquiryHistoryWriter.WriteAsync(new InquiryHistory
            {
                NationalId = request.NationalId,
                InquiryType = "Sequence",
                SequenceNumber = vehicle.SequenceNumber,
                CreatedAt = DateTime.UtcNow
            });



            _logger.LogInformation("Inquiry by sequence number completed successfully: {SequenceNumber}" ,  request.SequenceNumber);

            return _mapper.Map<InquiryResponse>(vehicle);
        }
    }
}