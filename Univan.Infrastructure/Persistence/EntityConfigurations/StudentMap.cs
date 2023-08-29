using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Univan.Domain.Entities;

namespace Univan.Infrastructure.Persistence.EntityConfigurations
{
    public class StudentMap : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Student");
            builder.HasKey(c => c.StudentId);
            builder.Property(d => d.Id).HasColumnName("UserId");
        }
    }
}
