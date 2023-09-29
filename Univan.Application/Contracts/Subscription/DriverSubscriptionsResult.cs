namespace Univan.Application.Contracts.Subscription
{
    public class DriverSubscriptionsResult
    {
        public int AvailableSeats { get; set; }
        public List<DriverStudents> Students { get; set; }
    }
}
