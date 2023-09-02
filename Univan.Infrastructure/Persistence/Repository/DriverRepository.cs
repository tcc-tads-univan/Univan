using Microsoft.EntityFrameworkCore;
using Univan.Domain.Entities;
using Univan.Domain.Repositories;
using Univan.Infrastructure.Persistence.Context;

namespace Univan.Infrastructure.Persistence.Repository
{
    public class DriverRepository : IDriverRepository
    {
        private readonly UnivanContext _dbContext;
        public DriverRepository(UnivanContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Driver> GetDriverById(int userId)
        {
            return await _dbContext.User.OfType<Driver>().FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task SaveDriver(Driver driver)
        {
            await _dbContext.AddAsync(driver);
            await _dbContext.SaveChangesAsync();
        }
    }
}
