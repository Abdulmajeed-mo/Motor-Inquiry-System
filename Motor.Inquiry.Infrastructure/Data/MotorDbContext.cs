using Microsoft.EntityFrameworkCore;
using Motor.Inquiry.Domain.Entities;

namespace Motor.Inquiry.Infrastructure.Data
{

    public class MotorDbContext : DbContext
    {

        public MotorDbContext(DbContextOptions<MotorDbContext> options) : base(options)
        {

        }
        public DbSet<InquiryHistory> InquiryHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the InquiryHistory entity
           
            modelBuilder.Entity<InquiryHistory>(entity =>
            {
                entity.HasKey(e => e.InquiryHistoryId);
                entity.Property(e => e.InquiryType).IsRequired();
                entity.Property(e => e.NationalId).IsRequired().HasMaxLength(10);
                entity.Property(e => e.PlateLetters).HasMaxLength(3);
                entity.Property(e => e.PlateNumber);
                entity.HasIndex(e => e.NationalId);
                entity.HasIndex(e => e.SequenceNumber);
                entity.HasIndex(e => new{e.PlateNumber,e.PlateLetters});
                entity.HasIndex(e => e.CreatedAt);
            });
        }
    }
}
