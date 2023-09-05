using Univan.Domain.Entities;

namespace Univan.Domain.Repositories
{
    public interface IDriverRepository : IUserBaseRepository<Driver>
    {
        Task<Vehicle> GetDriverVehicle(int driverId, int vehicleId);
    }
}
