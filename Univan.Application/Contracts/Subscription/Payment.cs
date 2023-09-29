using Univan.Domain.Enums;

namespace Univan.Application.Contracts.Subscription
{
    public class Payment
    {
        public DateTime? Date { get; set; }
        public decimal Value { get; set; }
        public PaymentStatus Status { get; set; }
    }
}