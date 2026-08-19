using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Motor.Inquiry.Domain.Entities;

namespace Motor.Inquiry.Infrastructure.Data.Configurations
{
    public class InquiryHistoryConfiguration : IEntityTypeConfiguration<InquiryHistory>
    {
        public void Configure(EntityTypeBuilder<InquiryHistory> entity)
        {
            entity.HasKey(e => e.InquiryHistoryId);

            entity.Property(e => e.InquiryType)
                .IsRequired();

            entity.Property(e => e.NationalId)
                .IsRequired()
                .HasMaxLength(10);

            entity.Property(e => e.PlateLetters)
                .HasMaxLength(3);

            entity.HasIndex(e => e.NationalId);
            entity.HasIndex(e => e.SequenceNumber);
            entity.HasIndex(e => new { e.PlateNumber, e.PlateLetters });
            entity.HasIndex(e => e.CreatedAt);
        }
    }
}