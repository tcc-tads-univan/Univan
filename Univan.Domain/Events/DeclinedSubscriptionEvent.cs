using MediatR;

namespace Univan.Domain.Events
{
    public class DeclinedSubscriptionEvent : INotification
    {
        public DeclinedSubscriptionEvent(int driverId, int studentId)
        {
            DriverId = driverId;
            StudentId = studentId;
        }

        public int DriverId { get; set; }
        public int StudentId { get; set; }
    }
}
