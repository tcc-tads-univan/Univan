using MediatR;

namespace Univan.Domain.Events
{
    public class DeclinedSubscriptionMessage : INotification
    {
        public DeclinedSubscriptionMessage(int driverId, int studentId)
        {
            DriverId = driverId;
            StudentId = studentId;
        }

        public int DriverId { get; set; }
        public int StudentId { get; set; }
    }
}
