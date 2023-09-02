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
    }
}
