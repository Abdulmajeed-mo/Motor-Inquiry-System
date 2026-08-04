using Motor.Inquiry.Domain.Entities;

namespace Motor.Inquiry.Application.Interfaces
{
    public interface IInquiryHistoryWriter
    {

        Task WriteAsync(InquiryHistory history);


    }
}