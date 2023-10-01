using Microsoft.EntityFrameworkCore;
using Univan.Domain.Entities;
using Univan.Domain.Repositories;
using Univan.Infrastructure.Persistence.Context;

namespace Univan.Infrastructure.Persistence.Repository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly UnivanContext _dbContext;
        public AuthenticationRepository(UnivanContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<User> Login(string email)
        {
            return await _dbContext.Set<User>().FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
