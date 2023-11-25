using Univan.Domain.Enums;

namespace Univan.Application.Contracts.Subscription
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public DateTime? Date { get; set; }
        public decimal Value { get; set; }
        public PaymentStatus Status { get; set; }
    }
}