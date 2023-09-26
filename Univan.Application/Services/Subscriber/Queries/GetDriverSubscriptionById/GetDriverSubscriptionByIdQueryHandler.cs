using FluentResults;
using MediatR;
using Univan.Application.Contracts.Subscription;
using Univan.Application.Validation;
using Univan.Domain.Enums;

namespace Univan.Application.Services.Subscriber.Queries.GetDriverSubscriptionById
{
    public class GetDriverSubscriptionByIdQueryHandler : IRequestHandler<GetDriverSubscriptionByIdQuery, Result<DriverStudentSubscriptionResult>>
    {
        public async Task<Result<DriverStudentSubscriptionResult>> Handle(GetDriverSubscriptionByIdQuery request, CancellationToken cancellationToken)
        {
            DriverStudentSubscriptionResult driverStudentSubscription = null;
            //var driverStudentSubscription = _subscriptionRepository.GetDriverSubscriptionById(request.DriverId, request.SubscriptionId);

            /*
             *  select for subscription table by driverId and subscriptionId
             *  Include(Student)
             *  Include(Payments)
             */

            if (driverStudentSubscription is null)
            {
                return Result.Fail(ValidationErrors.Subscription.StudentSubscriptionNotFound);
            }

            var result = new DriverStudentSubscriptionResult()
            {
                Name = "Mateus",
                Phone = "123",
                FinalAddress = "123",
                Payment = new Payment()
                {
                    Date = DateTime.Now,
                    Status = PaymentStatus.PAID,
                    Value = 232.23M
                }
            };

            return Result.Ok(result);
        }
    }
}
