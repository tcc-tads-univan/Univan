namespace Univan.Application.Contracts.Subscription
{
    public class DriverStudentSubscriptionResult
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string FinalAddress { get; set; }
        public PaymentResult Payment { get; set; }
    }
}
