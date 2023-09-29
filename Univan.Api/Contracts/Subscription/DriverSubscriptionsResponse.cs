namespace Univan.Api.Contracts.Subscription
{
    public class DriverSubscriptionsResponse
    {
        public int AvailableSeats { get; set; }
        public List<DriverStudents> Students { get; set; }

        public class DriverStudents
        {
            public int SubscriptionId { get; set; }
            public string Name { get; set; }
            public string SubscriptionStatus { get; set; }
        }
    }
}
