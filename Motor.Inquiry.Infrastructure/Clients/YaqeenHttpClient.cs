using Microsoft.Extensions.Logging;
using Motor.Inquiry.Application.DTOs;
using Motor.Inquiry.Application.Interfaces;
using Motor.Inquiry.Domain.Exceptions;
using System.Net;
using System.Net.Http.Json;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.Http;

namespace Motor.Inquiry.Infrastructure.Clients
{
    public class YaqeenHttpClient : IYaqeenHttpClient
    {


        //private field
        private readonly HttpClient _httpClient;

        private readonly ILogger<YaqeenHttpClient> _logger;
        private readonly IMemoryCache _memoryCache;
        private readonly IHttpContextAccessor _httpContextAccessor;

        //constructor
        public YaqeenHttpClient(HttpClient httpClient, ILogger<YaqeenHttpClient> logger, IMemoryCache memoryCache, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _logger = logger;
            _memoryCache = memoryCache;
            _httpContextAccessor = httpContextAccessor;
        }



        //Action Method
        



        public async Task<bool> ValidateCitizenAsync(CitizenValidationRequest request)
        {

            var cacheKey = $"citizen:{request.NationalId}:{request.DateOfBirth}";

            if (_memoryCache.TryGetValue(cacheKey, out bool cachedResult))
            {
                _logger.LogInformation("Citizen validation found in cache.");

                return cachedResult;
            }

            _logger.LogInformation("Citizen validation not found in cache. Calling Yaqeen API.");

            var correlationId =  _httpContextAccessor.HttpContext?.Request.Headers["X-Correlation-ID"].FirstOrDefault()?? Guid.NewGuid().ToString();

            var httpRequest = new HttpRequestMessage(HttpMethod.Post, "/api/yaqeen/citizen/validate")
            {
                Content = JsonContent.Create(request)
            };

            httpRequest.Headers.Add("X-Correlation-ID", correlationId);
            
            var response = await _httpClient.SendAsync(httpRequest);

            _logger.LogInformation("Yaqeen API response: {StatusCode}, Success: {Success}",response.StatusCode,response.IsSuccessStatusCode);

            var result = response.IsSuccessStatusCode;

            _memoryCache.Set(cacheKey,result,TimeSpan.FromMinutes(5));

            _logger.LogInformation("Citizen validation response cached.");

            return result;
        }






        public async Task<VehicleInquiryDto> GetVehicleBySequenceAsync(int sequenceNumber)
        {
            var cacheKey = $"vehicle:sequence:{sequenceNumber}";

            if (_memoryCache.TryGetValue(cacheKey, out VehicleInquiryDto? cachedVehicle))
            {
                _logger.LogInformation("Vehicle found in cache.");
                return cachedVehicle!;
            }

            _logger.LogInformation("Vehicle not found in cache. Calling Yaqeen API.");

            var correlationId =_httpContextAccessor.HttpContext?.Request.Headers["X-Correlation-ID"].FirstOrDefault()?? Guid.NewGuid().ToString();

            var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"/api/yaqeen/vehicle/sequence/{sequenceNumber}");

            httpRequest.Headers.Add("X-Correlation-ID", correlationId);

            var response = await _httpClient.SendAsync(httpRequest);


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
                                                        //مدة التخزين محددة بـ 5 دقائق.
            _memoryCache.Set(cacheKey,vehicle,TimeSpan.FromMinutes(5));

            _logger.LogInformation("Vehicle response cached.");

            return vehicle;
        }












        public async Task<VehicleInquiryDto> GetVehicleByPlateAsync(
         string plateNumber,string plateLetters)
        {
            var cacheKey = $"vehicle:plate:{plateNumber}:{plateLetters}";

            if (_memoryCache.TryGetValue(cacheKey, out VehicleInquiryDto? cachedVehicle))
                 {
                _logger.LogInformation("Vehicle found in cache.");
                
                return cachedVehicle!;
            }

            _logger.LogInformation("Vehicle not found in cache. Calling Yaqeen API.");

            var correlationId =_httpContextAccessor.HttpContext?.Request.Headers["X-Correlation-ID"].FirstOrDefault()?? Guid.NewGuid().ToString();

            var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"/api/yaqeen/vehicle/plate?plateNumber={plateNumber}&plateLetters={plateLetters}");

            httpRequest.Headers.Add("X-Correlation-ID", correlationId);

            var response = await _httpClient.SendAsync(httpRequest);
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
                                               //مدة التخزين محددة بـ 5 دقائق.
            _memoryCache.Set(cacheKey,vehicle,TimeSpan.FromMinutes(5));

            _logger.LogInformation("Vehicle response cached.");

            return vehicle;
        }
    }
}
