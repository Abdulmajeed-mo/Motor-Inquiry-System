using Motor.Inquiry.Application.Interfaces;
using Motor.Inquiry.Domain.Entities;
using Motor.Inquiry.Infrastructure.Data;

namespace Motor.Inquiry.Infrastructure.Services
{
    public class InquiryHistoryWriter : IInquiryHistoryWriter
    {
        private readonly MotorDbContext _dbContext;

        public InquiryHistoryWriter(MotorDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task WriteAsync(InquiryHistory history)
        {
            //AddCheckConstraintOperation Transaction
            await using var transaction = await _dbContext.Database.BeginTransactionAsync();

            try
            {
                _dbContext.InquiryHistories.Add(history);
                await _dbContext.SaveChangesAsync();
                throw new Exception("Rollback test");
                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}