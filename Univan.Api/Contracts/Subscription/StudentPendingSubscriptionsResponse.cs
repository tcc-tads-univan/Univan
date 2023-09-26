namespace Univan.Api.Contracts.Subscription
{
    public class StudentPendingSubscriptionsResponse
    {
        public string DriverName { get; set; }
        public string DriverPhone { get; set; }
        public decimal MonthlyFee { get; set; }
        public int ExpirationDay { get; set; }
    }
}
