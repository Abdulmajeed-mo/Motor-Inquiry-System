using Motor.Inquiry.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace Motor.Inquiry.Application.Interfaces
{
    public interface IInquiryService
    {

       Task< InquiryResponse> GetInquiryBySequenceNumber(InquiryBySequenceRequest request);
       Task <InquiryResponse> GetInquiryByPlateNumber(InquiryByPlateRequest request);   

    }
}
