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
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Subscription> Subscription { get; set; }
        public DbSet<SubscriptionHistory> SubscriptionHistory { get; set; }

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

            builder.Entity<Address>(new AddressMap().Configure);
            builder.Entity<Student>().HasOne<Address>(s => s.Address).WithOne(a => a.Student).HasForeignKey<Student>(s => s.AddressId);

            builder.Entity<Subscription>(new SubscriptionMap().Configure);
            builder.Entity<SubscriptionHistory>(new SubscriptionHistoryMap().Configure);

            builder.Entity<Subscription>().HasMany<SubscriptionHistory>(s => s.SubscriptionHistory).WithOne(sh => sh.Subscription).HasForeignKey(sh => sh.SubscriptionId);

            builder.Entity<Subscription>().HasOne<Driver>(s => s.Driver).WithMany(d => d.Subscriptions).HasForeignKey(s => s.DriverId).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Subscription>().HasOne<Student>(s => s.Student).WithOne(d => d.Subscription).HasForeignKey<Subscription>(s => s.StudentId).OnDelete(DeleteBehavior.Restrict); ;

        }
    }
}
