using FluentResults;
using MediatR;
using Univan.Application.Contracts.Subscription;
using Univan.Application.Validation;
using Univan.Domain.Entities;
using Univan.Domain.Enums;
using Univan.Domain.Repositories;

namespace Univan.Application.Services.Subscriber.Queries.GetDriverSubscriptions
{
    public class GetDriverSubscriptionsQueryHandler : IRequestHandler<GetDriverSubscriptionsQuery, Result<DriverSubscriptionsResult>>
    {
        private readonly IDriverRepository _driverRepository;
        public GetDriverSubscriptionsQueryHandler(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }
        public async Task<Result<DriverSubscriptionsResult>> Handle(GetDriverSubscriptionsQuery request, CancellationToken cancellationToken)
        {
            var driverSubscriptions = await _driverRepository.GetSubscriptions(request.DriverId);

            if (driverSubscriptions is null)
            {
                return Result.Fail(ValidationErrors.Subscription.DriverSubscriptionNotFound);
            }

            var result = new DriverSubscriptionsResult()
            {
                AvailableSeats = CalculateAvailableSeats(driverSubscriptions),
                Students = driverSubscriptions.Select(ds => new DriverStudents()
                {
                    Name = ds.Student.Name,
                    SubscriptionId = ds.SubscriptionId
                }).ToList()
            };

            return Result.Ok(result);
        }

        private int CalculateAvailableSeats(IEnumerable<Subscription> driverSubscriptions)
        {
            var totalVanSeats = driverSubscriptions.FirstOrDefault().Driver.Vehicle.Seats;
            var totalSubscriptions = driverSubscriptions.Count();
            return totalVanSeats - totalSubscriptions;
        }
    }
}
