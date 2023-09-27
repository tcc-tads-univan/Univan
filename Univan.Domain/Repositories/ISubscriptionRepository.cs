using Univan.Domain.Entities;

namespace Univan.Domain.Repositories
{
    public interface ISubscriptionRepository
    {
        Task CreateSubscription(Subscription subscription);
        Task<Subscription> GetPendingSubscriptionById(int subscriptionId);
        Task SaveSubscription();
    }
}
