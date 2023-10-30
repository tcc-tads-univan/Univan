using SharedContracts.Events;

namespace Univan.Application.Abstractions.Messaging
{
    public interface IMessageSender
    {
        Task SendEvent(BaseUnivanEvent eventMessage);
    }
}
