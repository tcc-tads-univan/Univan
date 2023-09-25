using FluentResults;
using MediatR;
using Univan.Application.Validation;
using Univan.Domain.Enums;

namespace Univan.Application.Services.Subscriber.Command.DeclineSubscription
{
    public class DeclineSubscriptionCommandHandler : IRequestHandler<DeclineSubscriptionCommand, Result>
    {
        public async Task<Result> Handle(DeclineSubscriptionCommand request, CancellationToken cancellationToken)
        {
            Object subscription = null;
            //var subscription = _subscriptionRepository.GetSubscriptionById(request.SubscriptionId);
            if (subscription == null)
            {
                return Result.Fail(ValidationErrors.Subscription.StudentSubscriptionNotFound);
            }

            //subscription.Status = SubscriptionStatus.REFUSED;

            //_subscriptionRepository.SaveSubscription();

            return Result.Ok();
        }
    }
}
