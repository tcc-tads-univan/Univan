using FluentResults;
using MediatR;
using Univan.Application.Validation;
using Univan.Domain.Enums;
using Univan.Domain.Events;
using Univan.Domain.Repositories;

namespace Univan.Application.Services.Subscriber.Command.AcceptSubscription
{
    public class AcceptSubscriptionCommandHandler : IRequestHandler<AcceptSubscriptionCommand, Result>
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IMediator _mediator;
        public AcceptSubscriptionCommandHandler(ISubscriptionRepository subscriptionRepository, IMediator mediator)
        {
            _subscriptionRepository = subscriptionRepository;
            _mediator = mediator;
        }
        public async Task<Result> Handle(AcceptSubscriptionCommand request, CancellationToken cancellationToken)
        {
            var subscription = await _subscriptionRepository.GetPendingSubscriptionById(request.SubscriptionId);

            if (subscription == null)
            {
                return Result.Fail(ValidationErrors.Subscription.NotFound);
            }

            subscription.Status = nameof(SubscriptionStatus.ACTIVE);

            await _subscriptionRepository.SaveSubscription();

            await _mediator.Publish(new AcceptedSubscriptionEvent(subscription.DriverId, subscription.StudentId));

            return Result.Ok();
        }
    }
}
