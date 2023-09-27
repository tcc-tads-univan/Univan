using FluentResults;
using MediatR;
using Univan.Application.Validation;
using Univan.Domain.Enums;
using Univan.Domain.Repositories;

namespace Univan.Application.Services.Subscriber.Command.DeclineSubscription
{
    public class DeclineSubscriptionCommandHandler : IRequestHandler<DeclineSubscriptionCommand, Result>
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        public DeclineSubscriptionCommandHandler(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        public async Task<Result> Handle(DeclineSubscriptionCommand request, CancellationToken cancellationToken)
        {
            var subscription = await _subscriptionRepository.GetPendingSubscriptionById(request.SubscriptionId);
            
            if (subscription == null)
            {
                return Result.Fail(ValidationErrors.Subscription.SubscriptionNotFound);
            }

            subscription.Status = nameof(SubscriptionStatus.REFUSED);

            await _subscriptionRepository.SaveSubscription();

            return Result.Ok();
        }
    }
}
