
namespace Motor.Inquiry.Application.DTOs
{
    public class InquiryByPlateRequest
    {   
        public string PlateNumber { get; set; }
        public string PlateLetters { get; set; }
        public string NationalId { get; set; }
        public DateOnly DateOfBirth { get; set; }
    }
}
