using FluentResults;
using MediatR;
using Univan.Application.Contracts.Subscription;
using Univan.Domain.Repositories;

namespace Univan.Application.Services.Subscriber.Queries.GetStudentPendingSubscriptions
{
    public class GetStudentPendingSubscriptionsQueryHandler : IRequestHandler<GetStudentPendingSubscriptionsQuery, Result<List<StudentPendingSubscriptionsResult>>>
    {
        private readonly IStudentRepository _studentRepository;
        public GetStudentPendingSubscriptionsQueryHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository; 
        }

        public async Task<Result<List<StudentPendingSubscriptionsResult>>> Handle(GetStudentPendingSubscriptionsQuery request, CancellationToken cancellationToken)
        {
            var pendingSubscriptions = await _studentRepository.GetPendingSubscription(request.StudentId);

            var result = pendingSubscriptions.Select(ps => new StudentPendingSubscriptionsResult()
            {
                SubscriptionId = ps.SubscriptionId,
                DriverName = ps.Driver.Name,
                DriverPhone = ps.Driver.PhoneNumber,
                DriverPhoto = ps.Driver.PhotoUrl,
                ExpirationDay = ps.ExpirationDay,
                MonthlyFee = ps.MonthlyFee
            }).ToList();

            return Result.Ok(result);
        }
    }
}
