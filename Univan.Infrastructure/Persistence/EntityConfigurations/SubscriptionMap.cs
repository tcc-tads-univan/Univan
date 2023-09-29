using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Univan.Domain.Entities;

namespace Univan.Infrastructure.Persistence.EntityConfigurations
{
    public class SubscriptionMap : IEntityTypeConfiguration<Subscription>
    {
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder.ToTable("Subscription");
            builder.HasKey(s => s.SubscriptionId);
            builder.Property(s => s.MonthlyFee).IsRequired().HasPrecision(7, 2);
            builder.Property(s => s.ExpirationDay).IsRequired();
            builder.Property(s => s.Status).IsRequired().HasMaxLength(32);
        }
    }
}
