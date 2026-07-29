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
        public InquiryResponse GetInquiryByPlateNumber(InquiryByPlateRequest request)
        {
            return new InquiryResponse
            {

                PlateNumber = request.PlateNumber,
                PlateLetters = request.PlateLetters,
                Make = "Hyundai",
                Model = "Elantra",
                ModelYear = 2024,
                Color = "Black",
                ChassisNumber = "TEST987654321"

            };

        }    
                
                

        public InquiryResponse GetInquiryBySequenceNumber(InquiryBySequenceRequest request)
        {
            return new InquiryResponse
            {
                SequenceNumber = request.SequenceNumber,
                PlateNumber = "1234",
                PlateLetters = "ABC",
                Make = "Toyota",
                Model = "Camry",
                ModelYear = 2023,
                Color = "White",
                ChassisNumber = "TEST123456789"
            };
        }
    }
}