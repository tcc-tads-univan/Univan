﻿using Microsoft.EntityFrameworkCore;
using Univan.Domain.Entities;
using Univan.Domain.Repositories;
using Univan.Infrastructure.Persistence.Context;

namespace Univan.Infrastructure.Persistence.Repository
{
    public class UserBaseRepository<T> : IUserBaseRepository<T> where T : User
    {
        private readonly UnivanContext _dbContext;
        public UserBaseRepository(UnivanContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<T> GetUserById(int userId)
        {
            return await _dbContext.User.OfType<T>().FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task SaveUserAsync(T user)
        {
            await _dbContext.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateUser(T user)
        {
            var oldUser = await _dbContext.User.OfType<T>().FirstOrDefaultAsync(u => u.Id == user.Id);
            _dbContext.Entry(oldUser).CurrentValues.SetValues(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}
