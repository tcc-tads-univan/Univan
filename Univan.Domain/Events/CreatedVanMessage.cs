using MediatR;

namespace Univan.Domain.Events
{
    public class CreatedVanMessage : INotification
    {
        public CreatedVanMessage(int driverId, string placeId)
        {
            DriverId = driverId;
            PlaceId = placeId;
        }

        public int DriverId { get; set; }
        public string PlaceId { get; set; }
    }
}
