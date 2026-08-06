using AutoMapper;
using Motor.Inquiry.Application.DTOs;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Motor.Inquiry.Application.Mapping;

public class InquiryMappingProfile : Profile
{
    public InquiryMappingProfile()
    {
        CreateMap<VehicleInquiryDto, InquiryResponse>();
    }
}