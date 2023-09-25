using FluentResults;
using MediatR;
using Univan.Application.Validation;
using Univan.Domain.Enums;

namespace Univan.Application.Services.Subscriber.Command.AcceptSubscription
{
    public class AcceptSubscriptionCommandHandler : IRequestHandler<AcceptSubscriptionCommand, Result>
    {
        public async Task<Result> Handle(AcceptSubscriptionCommand request, CancellationToken cancellationToken)
        {
            Object subscription = null;
            //var subscription = _subscriptionRepository.GetSubscriptionById(request.SubscriptionId);
            if (subscription == null)
            {
                return Result.Fail(ValidationErrors.Subscription.SubscriptionNotFound);
            }

            //subscription.Status = SubscriptionStatus.ACTIVE;

            //_subscriptionRepository.SaveSubscription();

            return Result.Ok();
        }
    }
}
