using Motor.Inquiry.Application.DTOs;
using Motor.Inquiry.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<InquiryResponse> GetVehicleBySequenceAsync(int sequenceNumber)
        {
            var response = await _httpClient.GetFromJsonAsync<InquiryResponse>($"/api/yaqeen/vehicle/sequence/{sequenceNumber}");

            return response;
        }
        public async Task<InquiryResponse> GetVehicleByPlateAsync( string plateNumber,string plateLetters)
        {
            var response = await _httpClient.GetFromJsonAsync<InquiryResponse>($"/api/yaqeen/vehicle/plate?plateNumber={plateNumber}&plateLetters={plateLetters}");

            return response;
        }

    }
}
