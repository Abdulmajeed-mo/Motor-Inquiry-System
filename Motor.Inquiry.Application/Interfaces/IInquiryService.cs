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

        InquiryResponse GetInquiryBySequenceNumber(InquiryBySequenceRequest request);
        InquiryResponse GetInquiryByPlateNumber(InquiryByPlateRequest request);   

    }
}
