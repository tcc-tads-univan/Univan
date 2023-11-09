namespace Univan.Domain.Entities
{
    public class SubscriptionHistory
    {
        public int SubscriptionHistoryId { get; set; }
        public int SubscriptionId { get; set; }
        public Subscription Subscription { get; set; }
        public decimal Value { get; set; }
        public DateTime? PaymentDate { get; set; }
        public DateTime IssueDate { get; set; }
        public string PaymentStatus { get; set; }
    }
}
