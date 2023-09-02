using Univan.Domain.Entities;

namespace Univan.Domain.Repositories
{
    public interface IDriverRepository
    {
        Task SaveDriver(Driver driver);
        Task<Driver> GetDriverById(int userId);
    }
}
