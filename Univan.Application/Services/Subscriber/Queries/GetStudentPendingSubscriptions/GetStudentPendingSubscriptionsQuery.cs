namespace Univan.Application.Services.Subscriber.Queries.GetStudentPendingSubscriptions
{
    public class GetStudentPendingSubscriptionsQuery
    {
        public int StudentId { get; set; }
        public GetStudentPendingSubscriptionsQuery(int studentId)
        {
            StudentId = studentId;
        }
    }
}
