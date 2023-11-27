using FluentResults;
using MediatR;

namespace Univan.Application.Services.Subscriber.Command.CancelSubscription
{
    public class CancelSubscriptionCommand : IRequest<Result>
    {
        public CancelSubscriptionCommand(int subscriptionId, int driverId)
        {
            SubscriptionId = subscriptionId;
            DriverId = driverId;
        }

        public int SubscriptionId { get; set; }
        public int DriverId { get; set; }
    }
}
