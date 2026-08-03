namespace Motor.Inquiry.Domain.Entities
{
    public class InquiryHistory
    {
        public int InquiryHistoryId { get; set; }

        public string NationalId { get; set; }

        public string InquiryType { get; set; }

        public int? SequenceNumber { get; set; }

        public string? PlateNumber { get; set; }

        public string? PlateLetters { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
