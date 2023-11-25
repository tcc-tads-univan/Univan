using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Univan.Domain.Entities;

namespace Univan.Infrastructure.Persistence.EntityConfigurations
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Name).IsRequired().HasMaxLength(120);
            builder.Property(u => u.Cpf).IsRequired().HasMaxLength(11);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(120);
            builder.Property(u => u.Birthdate).IsRequired();
            builder.Property(u => u.Password).IsRequired().HasMaxLength(500);
            builder.Property(u => u.PhotoUrl).IsRequired().HasMaxLength(200);
            builder.Property(u => u.Rating).HasPrecision(7,2);
            builder.Property(u => u.TotalRides);
            builder.Property(u => u.PhoneNumber).IsRequired().HasMaxLength(20);
        }
    }
}
