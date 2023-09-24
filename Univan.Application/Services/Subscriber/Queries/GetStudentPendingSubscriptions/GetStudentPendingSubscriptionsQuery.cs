using FluentResults;
using MediatR;
using Univan.Application.Contracts.Subscription;

namespace Univan.Application.Services.Subscriber.Queries.GetStudentPendingSubscriptions
{
    public class GetStudentPendingSubscriptionsQuery : IRequest<Result<StudentPendingSubscriptionsResult>>
    {
        public int StudentId { get; set; }
        public GetStudentPendingSubscriptionsQuery(int studentId)
        {
            StudentId = studentId;
        }
    }
}
