
namespace Motor.Inquiry.Application.DTOs
{
    public class InquiryBySequenceRequest
    {
        public int SequenceNumber { get; set; }
        public string NationalId { get; set; }
        public DateOnly DateOfBirth { get; set; }
    }
}
