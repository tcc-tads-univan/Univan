using Microsoft.EntityFrameworkCore;
using Univan.Domain.Entities;
using Univan.Domain.Enums;
using Univan.Domain.Repositories;
using Univan.Infrastructure.Persistence.Context;

namespace Univan.Infrastructure.Persistence.Repository
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly UnivanContext _dbContext;

        public SubscriptionRepository(UnivanContext context)
        {
            _dbContext = context;
        }

        public async Task CreateSubscription(Subscription subscription)
        {
            await _dbContext.AddAsync(subscription);
            await _dbContext.SaveChangesAsync();
        }

        public Task<Subscription> GetPendingSubscriptionById(int subscriptionId)
        {
            return _dbContext.Set<Subscription>()
                .FirstOrDefaultAsync(s => s.SubscriptionId == subscriptionId && s.Status == nameof(SubscriptionStatus.PENDING));
        }

        public Task<Subscription> GetSubscriptionByIdAndDriverId(int subscriptionId, int driverId)
        {
            return _dbContext.Set<Subscription>()
                .Include(s => s.SubscriptionHistory)
                .FirstOrDefaultAsync(s => s.SubscriptionId == subscriptionId &&
                    s.Status == nameof(SubscriptionStatus.ACTIVE) &&
                    s.DriverId == driverId);
        }

        public async Task RefuseSubscription(Subscription subscription)
        {
            _dbContext.Set<Subscription>().Remove(subscription);
            await _dbContext.SaveChangesAsync();
        }

        public async Task SaveSubscription()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
