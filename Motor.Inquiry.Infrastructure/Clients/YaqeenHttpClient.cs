using Microsoft.Extensions.Logging;
using Motor.Inquiry.Application.DTOs;
using Motor.Inquiry.Application.Interfaces;
using Motor.Inquiry.Domain.Exceptions;
using System.Net;
using System.Net.Http.Json;
using Microsoft.Extensions.Caching.Memory;

namespace Motor.Inquiry.Infrastructure.Clients
{
    public class YaqeenHttpClient : IYaqeenHttpClient
    {


        //private field
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<YaqeenHttpClient> _logger;
        private readonly HttpClient _httpClient;

        //constructor
        public YaqeenHttpClient(HttpClient httpClient, ILogger<YaqeenHttpClient> logger, IMemoryCache memoryCache)
        {
            _httpClient = httpClient;
            _logger = logger;
            _memoryCache = memoryCache;
        }



        //Action Method

        public async Task<bool> ValidateCitizenAsync(CitizenValidationRequest request)
        {
            var cacheKey = $"citizen:{request.NationalId}:{request.DateOfBirth}";

            if (_memoryCache.TryGetValue(cacheKey, out bool cachedResult))
            {
                _logger.LogInformation("Citizen validation found in cache for NationalId: {NationalId}",request.NationalId);

                return cachedResult;
            }

            _logger.LogInformation("Citizen validation not found in cache. Calling Yaqeen API for NationalId: {NationalId}",request.NationalId);

            var response = await _httpClient.PostAsJsonAsync("/api/yaqeen/citizen/validate",request);

            _logger.LogInformation("Yaqeen API response: {StatusCode}, Success: {Success}",response.StatusCode,response.IsSuccessStatusCode);

            var result = response.IsSuccessStatusCode;

            _memoryCache.Set(cacheKey,result,TimeSpan.FromMinutes(5));

            _logger.LogInformation("Citizen validation response cached for NationalId: {NationalId}",request.NationalId);

            return result;
        }






        public async Task<VehicleInquiryDto> GetVehicleBySequenceAsync(int sequenceNumber)
        {
            var cacheKey = $"vehicle:sequence:{sequenceNumber}";

            if (_memoryCache.TryGetValue(cacheKey, out VehicleInquiryDto? cachedVehicle))
            {
                _logger.LogInformation("Vehicle found in cache for sequence number: {SequenceNumber}",sequenceNumber);

                return cachedVehicle!;
            }

            _logger.LogInformation("Vehicle not found in cache. Calling Yaqeen API for sequence number: {SequenceNumber}",sequenceNumber);

            var response = await _httpClient.GetAsync($"/api/yaqeen/vehicle/sequence/{sequenceNumber}");

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new VehicleNotFoundException("Vehicle not found.");
            }

            response.EnsureSuccessStatusCode();

            var vehicle =await response.Content.ReadFromJsonAsync<VehicleInquiryDto>();

            if (vehicle is null)
            {
                throw new VehicleNotFoundException("Vehicle not found.");
            }

            _memoryCache.Set(cacheKey,vehicle,TimeSpan.FromMinutes(5));

            _logger.LogInformation("Vehicle response cached for sequence number: {SequenceNumber}", sequenceNumber);

            return vehicle;
        }












        public async Task<VehicleInquiryDto> GetVehicleByPlateAsync(
         string plateNumber,string plateLetters)
        {
            var cacheKey = $"vehicle:plate:{plateNumber}:{plateLetters}";

            if (_memoryCache.TryGetValue(cacheKey, out VehicleInquiryDto? cachedVehicle))
                 {
                _logger.LogInformation("Vehicle found in cache for plate: {PlateNumber}-{PlateLetters}",plateNumber,plateLetters);
                return cachedVehicle!;
            }

            _logger.LogInformation("Vehicle not found in cache. Calling Yaqeen API for plate: {PlateNumber}-{PlateLetters}",plateNumber,plateLetters);

            var response = await _httpClient.GetAsync(
                $"/api/yaqeen/vehicle/plate?plateNumber={plateNumber}&plateLetters={plateLetters}");

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new VehicleNotFoundException("Vehicle not found.");
            }

            response.EnsureSuccessStatusCode();

            var vehicle =await response.Content.ReadFromJsonAsync<VehicleInquiryDto>();

            if (vehicle is null)
            {
                throw new VehicleNotFoundException("Vehicle not found.");
            }

            _memoryCache.Set(cacheKey,vehicle,TimeSpan.FromMinutes(5));

            _logger.LogInformation("Vehicle response cached for plate: {PlateNumber}-{PlateLetters}",plateNumber,plateLetters);

            return vehicle;
        }
    }
}
