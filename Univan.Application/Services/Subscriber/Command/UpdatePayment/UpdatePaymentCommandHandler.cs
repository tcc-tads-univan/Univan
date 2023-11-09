using FluentResults;
using MediatR;
using Univan.Domain.Enums;
using Univan.Domain.Repositories;

namespace Univan.Application.Services.Subscriber.Command.UpdatePayment
{
    public class UpdatePaymentCommandHandler : IRequestHandler<UpdatePaymentCommand, Result>
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        public UpdatePaymentCommandHandler(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        public async Task<Result> Handle(UpdatePaymentCommand request, CancellationToken cancellationToken)
        {
            var subscription = await _subscriptionRepository.GetSubscriptionByIdAndDriverId(request.SubscriptionId, request.DriverId);

            var payment = subscription.SubscriptionHistory.FirstOrDefault(sb => sb.SubscriptionHistoryId == request.PaymentId);
            payment.PaymentStatus = nameof(PaymentStatus.PAID);
            payment.PaymentDate = DateTime.Now;

            await _subscriptionRepository.SaveSubscription();

            return Result.Ok();
        }
    }
}
