namespace Univan.Domain.Entities
{
    public class Subscription
    {
        public int SubscriptionId { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int DriverId { get; set; }
        public Driver Driver { get; set; }
        public int ExpirationDay { get; set; }
        public decimal MonthlyFee { get; set; }
        public string Status { get; set; }
        public virtual List<SubscriptionHistory> History { get; set; }

    }
}
