namespace Univan.Application.Contracts.Subscription
{
    public class StudentPendingSubscriptionsResult
    {
        public string DriverName { get; set; }
        public string DriverPhone { get; set; }
        public string DriverPhoto { get; set; }
        public decimal MonthlyFee { get; set; }
        public int ExpirationDay { get; set; }
    }
}
