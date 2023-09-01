using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Univan.Domain.Entities;

namespace Univan.Infrastructure.Persistence.EntityConfigurations
{
    public class DriverMap : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            builder.ToTable("Driver");
            builder.Property(d => d.Cnh).IsRequired().HasMaxLength(11);
            builder.Property(d => d.Id).HasColumnName("UserId");
        }
    }
}
