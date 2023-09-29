using FluentResults;
using MediatR;
using Univan.Application.Contracts.Subscription;
using Univan.Application.Validation;
using Univan.Domain.Enums;
using Univan.Domain.Repositories;

namespace Univan.Application.Services.Subscriber.Queries.GetStudentSubscription
{
    public class GetStudentSubscriptionQueryHandler : IRequestHandler<GetStudentSubscriptionQuery, Result<StudentSubscriptionResult>>
    {
        private readonly IStudentRepository _studentRepository;
        public GetStudentSubscriptionQueryHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<Result<StudentSubscriptionResult>> Handle(GetStudentSubscriptionQuery request, CancellationToken cancellationToken)
        {
            var studentSubscription = await _studentRepository.GetSubscription(request.StudentId);

            if(studentSubscription is null)
            {
                return Result.Fail(ValidationErrors.Subscription.StudentSubscriptionNotFound);
            }

            var result = new StudentSubscriptionResult()
            {
                DriverName = studentSubscription.Driver.Name,
                DriverPhone = studentSubscription.Driver.PhoneNumber,
                VehiclePlate = studentSubscription.Driver.Vehicle.Plate,
                Payments = studentSubscription.SubscriptionHistory.OrderByDescending(s => s.SubscriptionHistoryId).Select(sh => new Payment()
                {
                    Date = sh.PaymentDate.HasValue ? sh.PaymentDate.Value.Date : null,
                    Status = (PaymentStatus)Enum.Parse(typeof(PaymentStatus), sh.PaymentStatus),
                    Value = sh.Value
                }).ToList()
            };

            return Result.Ok(result);
        }
    }
}
