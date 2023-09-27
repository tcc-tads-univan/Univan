using FluentResults;
using MediatR;
using Univan.Application.Contracts.Subscription;
using Univan.Application.Validation;
using Univan.Domain.Entities;
using Univan.Domain.Enums;
using Univan.Domain.Repositories;

namespace Univan.Application.Services.Subscriber.Queries.GetDriverSubscriptionById
{
    public class GetDriverSubscriptionByIdQueryHandler : IRequestHandler<GetDriverSubscriptionByIdQuery, Result<DriverStudentSubscriptionResult>>
    {
        private readonly IDriverRepository _driverRepository;
        public GetDriverSubscriptionByIdQueryHandler(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        public async Task<Result<DriverStudentSubscriptionResult>> Handle(GetDriverSubscriptionByIdQuery request, CancellationToken cancellationToken)
        {
            var driverStudentSubscription = await _driverRepository.GetSubscriptionById(request.DriverId, request.SubscriptionId);

            if (driverStudentSubscription is null)
            {
                return Result.Fail(ValidationErrors.Subscription.StudentSubscriptionNotFound);
            }

            var result = new DriverStudentSubscriptionResult()
            {
                Name = driverStudentSubscription.Student?.Name,
                Phone = driverStudentSubscription.Student?.PhoneNumber,
                FinalAddress = "SEM AINDA",
                Payment = driverStudentSubscription.SubscriptionHistory.FirstOrDefault() is not null ? 
                    MapPayment(driverStudentSubscription.SubscriptionHistory.FirstOrDefault()) : null
            };

            return Result.Ok(result);
        }

        private Payment MapPayment(SubscriptionHistory subscriptionHistory)
        {
            return new Payment()
            {
                Date = subscriptionHistory.PaymentDate.Value,
                Value = subscriptionHistory.Value,
                Status = (PaymentStatus)Enum.Parse(typeof(PaymentStatus), subscriptionHistory.PaymentStatus)
            };
        }
    }
}
