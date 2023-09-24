using Univan.Domain.Enums;

namespace Univan.Application.Contracts.Subscription
{
    public class DriverStudentsResult
    {
        public int SubscriptionId { get; set; }
        public string Name { get; set; }
        public StudentSituation Situation { get; set; }
    }
}