using FluentResults;
using MediatR;
using Univan.Application.Validation;
using Univan.Domain.Enums;
using Univan.Domain.Repositories;

namespace Univan.Application.Services.Subscriber.Command.CancelSubscription
{
    public class CancelSubscriptionCommandHandler : IRequestHandler<CancelSubscriptionCommand, Result>
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        public CancelSubscriptionCommandHandler(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }
        public async Task<Result> Handle(CancelSubscriptionCommand request, CancellationToken cancellationToken)
        {
            var subscription = await _subscriptionRepository.GetSubscriptionByIdAndDriverId(request.SubscriptionId, request.DriverId);

            if (subscription is null)
            {
                return Result.Fail(ValidationErrors.Subscription.NotFound);
            }

            subscription.Status = nameof(SubscriptionStatus.CANCELED);

            await _subscriptionRepository.SaveSubscription();

            return Result.Ok();
        }
    }
}
