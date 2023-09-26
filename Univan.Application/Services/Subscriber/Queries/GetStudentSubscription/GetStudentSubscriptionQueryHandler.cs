using FluentResults;
using MediatR;
using Univan.Application.Contracts.Subscription;
using Univan.Application.Validation;
using Univan.Domain.Enums;

namespace Univan.Application.Services.Subscriber.Queries.GetStudentSubscription
{
    public class GetStudentSubscriptionQueryHandler : IRequestHandler<GetStudentSubscriptionQuery, Result<StudentSubscriptionResult>>
    {
        public async Task<Result<StudentSubscriptionResult>> Handle(GetStudentSubscriptionQuery request, CancellationToken cancellationToken)
        {
            StudentSubscriptionResult studentSubscription = null;
            //var studentSubscription = _subscriptionRepository.GetStudentSubscription(request.StudentId);
            
            /*
             *  select for subscription table by studentId.
             *  Include(Driver/Vehicle)
             *  Include(Payments)
             */

            if(studentSubscription is null) //Student null? change message
            {
                return Result.Fail(ValidationErrors.Subscription.StudentSubscriptionNotFound);
            }

            var result = new StudentSubscriptionResult()
            {
                DriverName = "Bla",
                DriverPhone = "Bla",
                VehiclePlate = "AS",
                Payments = new List<Payment>()
                {
                    new Payment()
                    {
                        Date = DateTime.Now,
                        Status = PaymentStatus.PENDING,
                        Value = 234.23M
                    },
                }
            };

            return Result.Ok(result);
        }
    }
}
