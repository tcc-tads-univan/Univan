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
                SubscriptionStatus = driverStudentSubscription.Status,
                FinalAddress = "SEM AINDA",
                Payment = driverStudentSubscription.SubscriptionHistory.Any() ? 
                    MapPayment(driverStudentSubscription.SubscriptionHistory
                    .OrderByDescending(s => s.SubscriptionHistoryId)
                    .FirstOrDefault()) : null
            };

            return Result.Ok(result);
        }

        private Payment MapPayment(SubscriptionHistory subHistory)
        {
            return new Payment()
            {
                Date = subHistory.PaymentDate.HasValue ? subHistory.PaymentDate.Value.Date : null,
                Value = subHistory.Value,
                Status = (PaymentStatus)Enum.Parse(typeof(PaymentStatus), subHistory.PaymentStatus)
            };
        }
    }
}
