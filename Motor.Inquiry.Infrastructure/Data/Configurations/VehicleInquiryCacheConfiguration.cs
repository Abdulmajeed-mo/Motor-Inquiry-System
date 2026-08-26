using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Motor.Inquiry.Domain.Entities;

namespace Motor.Inquiry.Infrastructure.Data.Configurations;

public class VehicleInquiryCacheConfiguration : IEntityTypeConfiguration<VehicleInquiryCache>
{
    public void Configure(EntityTypeBuilder<VehicleInquiryCache> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.CacheKey).IsRequired().HasMaxLength(200);

        builder.HasIndex(x => x.CacheKey).IsUnique();

        builder.Property(x => x.NationalId).HasMaxLength(20);

        builder.Property(x => x.PlateNumber).HasMaxLength(20);

        builder.Property(x => x.PlateLetters).HasMaxLength(20);

        builder.Property(x => x.Make).IsRequired().HasMaxLength(100);

        builder.Property(x => x.Model).IsRequired().HasMaxLength(100);

        builder.Property(x => x.Color).IsRequired().HasMaxLength(50);

        builder.Property(x => x.ChassisNumber).IsRequired().HasMaxLength(100);

        builder.Property(x => x.OwnerNationalId).IsRequired().HasMaxLength(20);

        builder.Property(x => x.CachedAt).IsRequired();
    }
}