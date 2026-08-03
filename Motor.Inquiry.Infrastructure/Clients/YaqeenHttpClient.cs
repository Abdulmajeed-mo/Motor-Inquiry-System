using Motor.Inquiry.Application.DTOs;
using Motor.Inquiry.Application.Interfaces;

using System.Net.Http.Json;


namespace Motor.Inquiry.Infrastructure.Clients
{
    public class YaqeenHttpClient : IYaqeenHttpClient
    {


       //private field

        private readonly HttpClient _httpClient;

        //constructor
        public YaqeenHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;

        }

        public async Task<bool> ValidateCitizenAsync(CitizenValidationRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/yaqeen/citizen/validate",request);
            return response.IsSuccessStatusCode;
        }
        public async Task<VehicleInquiryDto> GetVehicleBySequenceAsync(int sequenceNumber)
        {
            var response = await _httpClient.GetFromJsonAsync<VehicleInquiryDto>($"/api/yaqeen/vehicle/sequence/{sequenceNumber}");

            return response;
        }
        public async Task<VehicleInquiryDto> GetVehicleByPlateAsync( string plateNumber,string plateLetters)
        {
            var response = await _httpClient.GetFromJsonAsync<VehicleInquiryDto>($"/api/yaqeen/vehicle/plate?plateNumber={plateNumber}&plateLetters={plateLetters}");

            return response;
        }

    }
}
