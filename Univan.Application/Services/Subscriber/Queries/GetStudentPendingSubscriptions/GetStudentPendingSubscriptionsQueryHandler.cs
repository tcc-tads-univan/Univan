using FluentResults;
using MediatR;
using Univan.Application.Contracts.Subscription;

namespace Univan.Application.Services.Subscriber.Queries.GetStudentPendingSubscriptions
{
    public class GetStudentPendingSubscriptionsQueryHandler : IRequestHandler<GetStudentPendingSubscriptionsQuery, Result<StudentPendingSubscriptionsResult>>
    {
        public async Task<Result<StudentPendingSubscriptionsResult>> Handle(GetStudentPendingSubscriptionsQuery request, CancellationToken cancellationToken)
        {
            StudentPendingSubscriptionsResult pendingSubscriptions = null;
            //var pendingSubscriptions = _subscriptionRepository.GetStudentPendingSubscription(request.StudentId);

            /*
             *  select for subscription table by studentId and pending status. Lista de subscription
             */

            var result = new StudentPendingSubscriptionsResult()
            {
                DriverName = "Teste",
                DriverPhone = "Teste",
                ExpirationDay = 12,
                MonthlyFee = 213.23M
            };

            return Result.Ok(result);
        }
    }
}
