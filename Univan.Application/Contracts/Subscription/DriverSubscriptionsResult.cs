namespace Univan.Application.Contracts.Subscription
{
    public class DriverSubscriptionsResult
    {
        public int FreeSeats { get; set; }
        public List<DriverStudentsResult> Students { get; set; }
    }
}
