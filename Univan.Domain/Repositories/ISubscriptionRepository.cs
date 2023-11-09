using Univan.Domain.Entities;
using Univan.Domain.Enums;

namespace Univan.Domain.Repositories
{
    public interface ISubscriptionRepository
    {
        Task CreateSubscription(Subscription subscription);
        Task<Subscription> GetPendingSubscriptionById(int subscriptionId);
        Task<Subscription> GetSubscriptionByIdAndDriverId(int subscriptionId, int driverId);
        Task SaveSubscription();
        Task RefuseSubscription(Subscription subscription);
    }
}
