using FluentResults;
using MediatR;
using Univan.Application.Validation;
using Univan.Domain.Entities;
using Univan.Domain.Enums;
using Univan.Domain.Repositories;

namespace Univan.Application.Services.Subscriber.Command.CreatePayment
{
    public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, Result>
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        public CreatePaymentCommandHandler(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        public async Task<Result> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            var subscription = await _subscriptionRepository.GetSubscriptionByIdAndDriverId(request.SubscriptionId, request.DriverId);

            if(subscription is null)
            {
                return Result.Fail(ValidationErrors.Subscription.NotFound);
            }

            var lastPayment = subscription?.SubscriptionHistory.LastOrDefault();

            if (lastPayment?.IssueDate.Month == DateTime.Now.Month)
            {
                return Result.Fail(ValidationErrors.Subscription.OnlyOnePaymentPerMonth);
            }

            var payment = new SubscriptionHistory()
            {
                IssueDate = DateTime.Now,
                PaymentStatus = nameof(SubscriptionStatus.PENDING),
                Value = subscription.MonthlyFee
            };

            subscription.SubscriptionHistory.Add(payment);
            await _subscriptionRepository.SaveSubscription();

            return Result.Ok();
        }
    }
}
