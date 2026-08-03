using Motor.Inquiry.Application.DTOs;

namespace Motor.Inquiry.Application.Interfaces
{
    public interface IInquiryService
    {

       Task< InquiryResponse> GetInquiryBySequenceNumber(InquiryBySequenceRequest request);
       Task <InquiryResponse> GetInquiryByPlateNumber(InquiryByPlateRequest request);   

    }
}
