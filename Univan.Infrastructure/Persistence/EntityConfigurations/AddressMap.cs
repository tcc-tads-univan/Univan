using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Univan.Domain.Entities;

namespace Univan.Infrastructure.Persistence.EntityConfigurations
{
    internal class AddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address");
            builder.HasKey(u => u.Id);
            builder.Property(d => d.CompleteLineAddress).HasMaxLength(500);
            builder.Property(d => d.GooglePlaceId).HasMaxLength(120);
        }
    }
}
