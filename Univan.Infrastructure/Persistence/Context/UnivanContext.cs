using Microsoft.EntityFrameworkCore;
using Univan.Domain.Entities;
using Univan.Infrastructure.Persistence.EntityConfigurations;

namespace Univan.Infrastructure.Persistence.Context
{
    public class UnivanContext : DbContext
    {
        public UnivanContext(DbContextOptions<UnivanContext> options) : base(options)
        {

        }
        public DbSet<Student> Student { get; set; }
        public DbSet<Driver> Driver { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Student>(new StudentMap().Configure);
            builder.Entity<Driver>(new DriverMap().Configure);
            
            builder.Entity<User>().UseTptMappingStrategy();
            builder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            builder.Entity<User>().HasIndex(u => u.Cpf).IsUnique();

            builder.Entity<Vehicle>(new VehicleMap().Configure);
            builder.Entity<Driver>().HasOne<Vehicle>(d => d.Vehicle).WithOne(v => v.Driver).HasForeignKey<Driver>(d => d.VehicleId);
        }
    }
}
