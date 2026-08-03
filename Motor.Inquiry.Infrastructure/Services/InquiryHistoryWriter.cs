using Motor.Inquiry.Application.Interfaces;
using Motor.Inquiry.Domain.Entities;
using Motor.Inquiry.Infrastructure.Data;


namespace Motor.Inquiry.Infrastructure.Services
{
    public class InquiryHistoryWriter : IInquiryHistoryWriter
    {
        private readonly MotorDbContext _context;

        public InquiryHistoryWriter(MotorDbContext context)
        {
            _context = context;
        }

        public async Task WriteAsync(InquiryHistory history)
        {
            Console.WriteLine("========== HISTORY SAVED ==========");

            _context.InquiryHistories.Add(history);

            await _context.SaveChangesAsync();

            Console.WriteLine($"NationalId: {history.NationalId}");
            Console.WriteLine($"Type: {history.InquiryType}");
            Console.WriteLine($"Sequence: {history.SequenceNumber}");
        }
    }
}