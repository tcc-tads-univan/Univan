namespace Univan.Api.Contracts.Subscription
{
    public class DriverStudentSubscriptionResponse
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string FinalAddress { get; set; }
        public string SubscriptionStatus { get; set; }
        public PaymentResponse Payment { get; set; }
    }

}
