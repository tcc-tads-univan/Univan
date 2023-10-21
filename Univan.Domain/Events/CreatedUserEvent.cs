using MediatR;

namespace Univan.Domain.Events
{
    public class CreatedUserEvent : INotification
    {
        public CreatedUserEvent(int userId, string name, string email)
        {
            UserId = userId;
            Name = name;
            Email = email;
        }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
