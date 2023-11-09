using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Univan.Domain.Entities;

namespace Univan.Infrastructure.Persistence.EntityConfigurations
{
    public class SubscriptionHistoryMap : IEntityTypeConfiguration<SubscriptionHistory>
    {
        public void Configure(EntityTypeBuilder<SubscriptionHistory> builder)
        {
            builder.ToTable("SubscriptionHistory");
            builder.HasKey(s => s.SubscriptionHistoryId);
            builder.Property(s => s.PaymentStatus).IsRequired().HasMaxLength(32);
            builder.Property(s => s.PaymentDate);
            builder.Property(s => s.IssueDate);
            builder.Property(s => s.Value).IsRequired().HasPrecision(7,2);
        }
    }
}
