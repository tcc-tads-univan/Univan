using FluentResults;
using MediatR;

namespace Univan.Application.Services.Subscriber.Command.DeclineSubscription
{
    public class DeclineSubscriptionCommand : IRequest<Result>
    {
        public int SubscriptionId { get; set; }
        public DeclineSubscriptionCommand(int subscriptionId)
        {
            SubscriptionId = subscriptionId;
        }
    }
}
