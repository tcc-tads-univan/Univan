using MediatR;

namespace Univan.Domain.Events
{
    public class StudentAddressEvent : INotification
    {
        public StudentAddressEvent(int driverId, int studentId, string placeId)
        {
            DriverId = driverId;
            StudentId = studentId;
            PlaceId = placeId;
        }

        public int DriverId { get; set; }
        public int StudentId { get; set; }
        public string PlaceId { get; set; }
    }
}
