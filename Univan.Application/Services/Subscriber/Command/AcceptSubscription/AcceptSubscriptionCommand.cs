using FluentResults;
using MediatR;

namespace Univan.Application.Services.Subscriber.Command.AcceptSubscription
{
    public class AcceptSubscriptionCommand : IRequest<Result>
    {
        public int SubscriptionId { get; set; }

        public AcceptSubscriptionCommand(int subscriptionId)
        {
            SubscriptionId = subscriptionId;
        }
    }
}
