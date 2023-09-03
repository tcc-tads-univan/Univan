using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Univan.Domain.Entities;

namespace Univan.Infrastructure.Persistence.EntityConfigurations
{
    public class VehicleMap : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable("Vehicle");
            builder.HasKey(v => v.Id);
            builder.Property(v => v.Plate).IsRequired().HasMaxLength(10);
            builder.Property(v => v.Model).HasMaxLength(32);
            builder.Property(v => v.Seats).IsRequired();
        }
    }
}
