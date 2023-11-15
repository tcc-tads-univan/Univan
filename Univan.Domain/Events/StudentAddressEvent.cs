using MediatR;

namespace Univan.Domain.Events
{
    public class UserAddressEvent : INotification
    {
        public UserAddressEvent(int userId, int? relatedTo, string placeId)
        {
            UserId = userId;
            RelatedTo = relatedTo;
            PlaceId = placeId;
        }

        public int UserId { get; set; }
        public int? RelatedTo { get; set; }
        public string PlaceId { get; set; }
    }
}
