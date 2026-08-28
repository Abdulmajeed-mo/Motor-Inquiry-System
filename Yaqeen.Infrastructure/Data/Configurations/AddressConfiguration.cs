using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Yaqeen.Domain.Entities;

namespace Yaqeen.Infrastructure.Data.Configurations;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.AddressLine).IsRequired();

        builder.HasOne(a => a.Citizen).WithMany(c => c.Addresses).HasForeignKey(a => a.CitizenId).OnDelete(DeleteBehavior.Cascade);
    }
}