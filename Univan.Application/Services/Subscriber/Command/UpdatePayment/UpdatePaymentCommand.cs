using FluentResults;
using MediatR;

namespace Univan.Application.Services.Subscriber.Command.UpdatePayment
{
    public class UpdatePaymentCommand : IRequest<Result>
    {
        public UpdatePaymentCommand(int subscriptionId, int driverId, int paymentId)
        {
            SubscriptionId = subscriptionId;
            DriverId = driverId;
            PaymentId = paymentId;
        }

        public int SubscriptionId { get; set; }
        public int DriverId { get; set; }
        public int PaymentId { get; set; }
    }
}
