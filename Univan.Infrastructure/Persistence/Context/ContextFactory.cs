using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Univan.Infrastructure.Persistence.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<UnivanContext>
    {
        public UnivanContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<UnivanContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\carpool; Integrated Security=true; Initial Catalog=Univan;");
            return new UnivanContext(optionsBuilder.Options);
        }
    }
}
