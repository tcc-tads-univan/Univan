namespace Univan.Application.Services.Subscriber.Queries.GetDriverSubscriptions
{
    public class GetDriverSubscriptionsQuery
    {
        public int DriverId { get; set; }
        public GetDriverSubscriptionsQuery(int driverId)
        {
            DriverId = driverId;
        }
    }
}
