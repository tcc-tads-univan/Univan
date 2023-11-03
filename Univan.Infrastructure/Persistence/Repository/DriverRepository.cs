using Microsoft.EntityFrameworkCore;
using Univan.Domain.Entities;
using Univan.Domain.Enums;
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

        public async Task DeleteDriverVehicle(int driverId, int vehicleId)
        {
            var vehicle = await _dbContext.Set<Vehicle>().FirstOrDefaultAsync(v => v.Driver.Id == driverId && v.Id == vehicleId);
            _dbContext.Set<Vehicle>().Remove(vehicle);
            await _dbContext.SaveChangesAsync();
        }

        public Task<Driver> GetDriverBasicInfo(int driverId)
        {
            return _dbContext.Set<Driver>().Include(u => u.Vehicle).FirstOrDefaultAsync(u => u.Id == driverId);
        }

        public Task<Vehicle> GetDriverVehicle(int driverId, int vehicleId)
        {
            return _dbContext.Set<Vehicle>().FirstOrDefaultAsync(v => v.Driver.Id == driverId && v.Id == vehicleId);
        }

        public Task<Subscription> GetSubscriptionById(int driverId, int subscriptionId)
        {
            return _dbContext.Set<Subscription>()
                .Include(s => s.Student)
                .Include(s => s.Student.Address)
                .Include(s => s.SubscriptionHistory)
                .FirstOrDefaultAsync(s => s.DriverId == driverId && s.SubscriptionId == subscriptionId);
        }

        public async Task<IEnumerable<Subscription>> GetSubscriptions(int driverId)
        {
            var statusList = new List<string>() 
            { 
                nameof(SubscriptionStatus.ACTIVE),
                nameof(SubscriptionStatus.PENDING) 
            };

            return await _dbContext.Set<Subscription>()
                .Include(s => s.Student)
                .Include(s => s.Driver.Vehicle)
                .Where(s => s.DriverId == driverId && statusList.Contains(s.Status)).ToListAsync();
        }
    }
}
