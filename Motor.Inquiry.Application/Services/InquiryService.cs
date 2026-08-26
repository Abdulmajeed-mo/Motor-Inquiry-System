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

        // Repository for database-backed Yaqeen inquiry caching.
        private readonly IVehicleInquiryCacheRepository _vehicleInquiryCacheRepository;


        private readonly ILogger<InquiryService> _logger;
        private readonly IYaqeenHttpClient _yaqeenHttpClient;
        private readonly IInquiryHistoryWriter _inquiryHistoryWriter;
        private readonly IMapper _mapper;


        //constructor
        public InquiryService(
            IYaqeenHttpClient yaqeenHttpClient,
            IInquiryHistoryWriter inquiryHistoryWriter,
            ILogger<InquiryService> logger,
            IMapper mapper,
            IVehicleInquiryCacheRepository vehicleInquiryCacheRepository)
        {
            _yaqeenHttpClient = yaqeenHttpClient;
            _inquiryHistoryWriter = inquiryHistoryWriter;
            _logger = logger;
            _mapper = mapper;
            _vehicleInquiryCacheRepository = vehicleInquiryCacheRepository;
        }


        //Action Method

        //search by plate number
        public async Task<InquiryResponse> GetInquiryByPlateNumber(
            InquiryByPlateRequest request,
            CancellationToken cancellationToken)
        {
            var cacheKey = $"Plate:{request.NationalId}:{request.PlateNumber}:{request.PlateLetters}";

            var cachedInquiry = await _vehicleInquiryCacheRepository
                .GetByCacheKeyAsync(cacheKey, cancellationToken);

            if (cachedInquiry is not null &&
                cachedInquiry.CachedAt >= DateTime.UtcNow.AddMonths(-1))
            {
                return new InquiryResponse
                {
                    SequenceNumber = cachedInquiry.SequenceNumber ?? 0,
                    PlateNumber = cachedInquiry.PlateNumber,
                    PlateLetters = cachedInquiry.PlateLetters,
                    Make = cachedInquiry.Make,
                    Model = cachedInquiry.Model,
                    ModelYear = cachedInquiry.ModelYear,
                    Color = cachedInquiry.Color,
                    ChassisNumber = cachedInquiry.ChassisNumber
                };
            }

            //citizen Validate
            var citizenRequest = new CitizenValidationRequest
            {
                NationalId = request.NationalId,
                DateOfBirth = request.DateOfBirth
            };

            var isCitizenValid = await _yaqeenHttpClient
                .ValidateCitizenAsync(citizenRequest, cancellationToken);

            if (!isCitizenValid)
            {
                throw new InvalidCitizenException("Invalid citizen.");
            }

            var vehicle = await _yaqeenHttpClient
                .GetVehicleByPlateAsync(
                    request.PlateNumber,
                    request.PlateLetters,
                    cancellationToken);


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

            _logger.LogInformation(
                "Inquiry by plate number completed successfully for PlateNumber: {PlateNumber}, PlateLetters: {PlateLetters}",
                request.PlateNumber,
                request.PlateLetters);

            var cache = new VehicleInquiryCache
            {
                CacheKey = cacheKey,
                NationalId = request.NationalId,
                SequenceNumber = vehicle.SequenceNumber,
                PlateNumber = vehicle.PlateNumber,
                PlateLetters = vehicle.PlateLetters,
                Make = vehicle.Make,
                Model = vehicle.Model,
                ModelYear = vehicle.ModelYear,
                Color = vehicle.Color,
                ChassisNumber = vehicle.ChassisNumber,
                OwnerNationalId = vehicle.OwnerNationalId,
                CachedAt = DateTime.UtcNow
            };

            if (cachedInquiry is null)
            {
                await _vehicleInquiryCacheRepository
                    .AddAsync(cache, cancellationToken);
            }
            else
            {
                cache.Id = cachedInquiry.Id;

                await _vehicleInquiryCacheRepository
                    .UpdateAsync(cache, cancellationToken);
            }

            return _mapper.Map<InquiryResponse>(vehicle);
        }


        //search by sequence number
        public async Task<InquiryResponse> GetInquiryBySequenceNumber(
            InquiryBySequenceRequest request,
            CancellationToken cancellationToken)
        {
            var cacheKey = $"Sequence:{request.NationalId}:{request.SequenceNumber}";

            var cachedInquiry = await _vehicleInquiryCacheRepository
                .GetByCacheKeyAsync(cacheKey, cancellationToken);

            if (cachedInquiry is not null &&
                cachedInquiry.CachedAt >= DateTime.UtcNow.AddMonths(-1))
            {
                return new InquiryResponse
                {
                    SequenceNumber = cachedInquiry.SequenceNumber ?? 0,
                    PlateNumber = cachedInquiry.PlateNumber,
                    PlateLetters = cachedInquiry.PlateLetters,
                    Make = cachedInquiry.Make,
                    Model = cachedInquiry.Model,
                    ModelYear = cachedInquiry.ModelYear,
                    Color = cachedInquiry.Color,
                    ChassisNumber = cachedInquiry.ChassisNumber
                };
            }

            //citizen Validate

            var citizenRequest = new CitizenValidationRequest
            {
                NationalId = request.NationalId,
                DateOfBirth = request.DateOfBirth
            };

            var isCitizenValid = await _yaqeenHttpClient
                .ValidateCitizenAsync(citizenRequest, cancellationToken);

            if (!isCitizenValid)
            {
                throw new InvalidCitizenException("Invalid citizen.");
            }

            var vehicle = await _yaqeenHttpClient
                .GetVehicleBySequenceAsync(
                    request.SequenceNumber,
                    cancellationToken);

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


            _logger.LogInformation(
                "Inquiry by sequence number completed successfully: {SequenceNumber}",
                request.SequenceNumber);

            var cache = new VehicleInquiryCache
            {
                CacheKey = cacheKey,
                NationalId = request.NationalId,
                SequenceNumber = vehicle.SequenceNumber,
                PlateNumber = vehicle.PlateNumber,
                PlateLetters = vehicle.PlateLetters,
                Make = vehicle.Make,
                Model = vehicle.Model,
                ModelYear = vehicle.ModelYear,
                Color = vehicle.Color,
                ChassisNumber = vehicle.ChassisNumber,
                OwnerNationalId = vehicle.OwnerNationalId,
                CachedAt = DateTime.UtcNow
            };

            if (cachedInquiry is null)
            {
                await _vehicleInquiryCacheRepository
                    .AddAsync(cache, cancellationToken);
            }
            else
            {
                cache.Id = cachedInquiry.Id;

                await _vehicleInquiryCacheRepository
                    .UpdateAsync(cache, cancellationToken);
            }

            return _mapper.Map<InquiryResponse>(vehicle);
        }
    }
}