using FluentResults;
using MediatR;
using Univan.Application.Contracts.Subscription;

namespace Univan.Application.Services.Subscriber.Queries.GetDriverSubscriptionById
{
    public class GetDriverSubscriptionByIdQuery : IRequest<Result<DriverStudentSubscriptionResult>>
    {
        public int DriverId { get; set; }
        public int SubscriptionId { get; set; }
        public GetDriverSubscriptionByIdQuery(int driverId, int subscriptionId)
        {
            DriverId = driverId;
            SubscriptionId = subscriptionId;
        }
    }
}
