using FluentResults;
using MediatR;
using Univan.Application.Contracts.Subscription;

namespace Univan.Application.Services.Subscriber.Queries.GetDriverSubscriptions
{
    public class GetDriverSubscriptionsQuery : IRequest<Result<DriverSubscriptionsResult>>
    {
        public int DriverId { get; set; }
        public GetDriverSubscriptionsQuery(int driverId)
        {
            DriverId = driverId;
        }
    }
}
