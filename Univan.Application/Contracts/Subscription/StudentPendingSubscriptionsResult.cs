namespace Univan.Application.Contracts.Subscription
{
    public class StudentPendingSubscriptionsResult
    {
        public int SubscriptionId { get; set; }
        public string DriverName { get; set; }
        public string DriverPhone { get; set; }
        public string DriverPhoto { get; set; }
        public decimal MonthlyFee { get; set; }
        public int ExpirationDay { get; set; }
    }
}
