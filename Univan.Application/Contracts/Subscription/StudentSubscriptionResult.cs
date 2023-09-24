namespace Univan.Application.Contracts.Subscription
{
    public class StudentSubscriptionResult
    {
        public string DriverName { get; set; }
        public string DriverPhone { get; set; }
        public string VehiclePlate { get; set; }
        public List<PaymentResult> Payments { get; set; }
    }
}
