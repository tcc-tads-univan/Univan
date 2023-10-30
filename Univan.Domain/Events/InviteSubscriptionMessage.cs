using MediatR;

namespace Univan.Domain.Events
{
    public class InviteSubscriptionMessage : INotification
    {
        public InviteSubscriptionMessage(int driverId, int studentId, decimal monthlyFee, int expirationDay)
        {
            DriverId = driverId;
            StudentId = studentId;
            MonthlyFee = monthlyFee;
            ExpirationDay = expirationDay;
        }

        public int DriverId { get; set; }
        public int StudentId { get; set; }
        public decimal MonthlyFee { get; set; }
        public int ExpirationDay { get; set; }
    }
}
