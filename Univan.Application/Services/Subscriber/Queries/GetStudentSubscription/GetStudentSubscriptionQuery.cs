using FluentResults;
using MediatR;
using Univan.Application.Contracts.Subscription;

namespace Univan.Application.Services.Subscriber.Queries.GetStudentSubscription
{
    public class GetStudentSubscriptionQuery : IRequest<Result<StudentSubscriptionResult>>
    {
        public int StudentId { get; set; }
        public GetStudentSubscriptionQuery(int studentId)
        {
            StudentId = studentId;
        }
    }
}
