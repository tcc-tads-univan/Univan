using FluentResults;
using MediatR;
using Univan.Application.Validation;
using Univan.Domain.Enums;
using Univan.Domain.Events;
using Univan.Domain.Repositories;

namespace Univan.Application.Services.Subscriber.Command.DeclineSubscription
{
    public class DeclineSubscriptionCommandHandler : IRequestHandler<DeclineSubscriptionCommand, Result>
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IMediator _mediator;
        public DeclineSubscriptionCommandHandler(ISubscriptionRepository subscriptionRepository, IMediator mediator)
        {
            _subscriptionRepository = subscriptionRepository;
            _mediator = mediator;
        }

        public async Task<Result> Handle(DeclineSubscriptionCommand request, CancellationToken cancellationToken)
        {
            var subscription = await _subscriptionRepository.GetPendingSubscriptionById(request.SubscriptionId);
            
            if (subscription == null)
            {
                return Result.Fail(ValidationErrors.Subscription.NotFound);
            }

            await _subscriptionRepository.RefuseSubscription(subscription);

            await _mediator.Publish(new DeclinedSubscriptionEvent(subscription.DriverId, subscription.StudentId));

            return Result.Ok();
        }
    }
}
