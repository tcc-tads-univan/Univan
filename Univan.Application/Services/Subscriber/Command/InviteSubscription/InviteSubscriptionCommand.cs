using FluentResults;
using MediatR;

namespace Univan.Application.Services.Subscriber.Command.InviteSubscription
{
    public class InviteSubscriptionCommand : IRequest<Result>
    {
        public int DriverId { get; set; }
        public int StudentId { get; set; }
        public decimal MonthlyFee { get; set; }
        public int ExpirationDay { get; set; }
    }
}
