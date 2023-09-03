using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Univan.Infrastructure.Persistence.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<UnivanContext>
    {
        public UnivanContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<UnivanContext>();
            optionsBuilder.UseSqlServer("Server=tcp:tccunivanfinal.database.windows.net,1433;Initial Catalog=univan;Persist Security Info=False;User ID=tccunivan;Password=Project!123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            return new UnivanContext(optionsBuilder.Options);
        }
    }
}
