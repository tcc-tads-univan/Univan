namespace Univan.Application.Services.Subscriber.Queries.GetStudentSubscription
{
    public class GetStudentSubscriptionQuery
    {
        public int StudentId { get; set; }
        public GetStudentSubscriptionQuery(int studentId)
        {
            StudentId = studentId;
        }
    }
}
