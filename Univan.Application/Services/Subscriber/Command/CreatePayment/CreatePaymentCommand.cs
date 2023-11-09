using FluentResults;
using MediatR;

namespace Univan.Application.Services.Subscriber.Command.CreatePayment
{
    public class CreatePaymentCommand : IRequest<Result>
    {
        public CreatePaymentCommand(int subscriptionId, int driverId)
        {
            SubscriptionId = subscriptionId;
            DriverId = driverId;
        }

        public int SubscriptionId { get; set; }
        public int DriverId { get; set; }
    }
}
