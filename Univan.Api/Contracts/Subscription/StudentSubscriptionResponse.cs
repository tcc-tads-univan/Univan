namespace Univan.Api.Contracts.Subscription
{
    public class StudentSubscriptionResponse
    {
        public string DriverName { get; set; }
        public string DriverPhone { get; set; }
        public string VehiclePlate { get; set; }
        public List<PaymentResponse> Payments { get; set; }
    }
}
