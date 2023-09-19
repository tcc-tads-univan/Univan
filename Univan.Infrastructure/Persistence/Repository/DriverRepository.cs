using Microsoft.EntityFrameworkCore;
using Univan.Domain.Entities;
using Univan.Domain.Repositories;
using Univan.Infrastructure.Persistence.Context;

namespace Univan.Infrastructure.Persistence.Repository
{
    public class DriverRepository : UserBaseRepository<Driver>, IDriverRepository
    {
        private readonly UnivanContext _dbContext;
        public DriverRepository(UnivanContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Driver> GetDriverBasicInfo(int driverId)
        {
            return _dbContext.Set<Driver>().Include(u => u.Vehicle).FirstOrDefaultAsync(u => u.Id == driverId);
        }

        public Task<Vehicle> GetDriverVehicle(int driverId, int vehicleId)
        {
            return _dbContext.Set<Vehicle>().FirstOrDefaultAsync(v => v.Driver.Id == driverId && v.Id == vehicleId);
        }
    }
}
