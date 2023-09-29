namespace Univan.Api.Contracts.Subscription
{
    public class PaymentResponse
    {
        public DateTime? Date { get; set; }
        public decimal Value { get; set; }
        public string Status { get; set; }
    }
}
