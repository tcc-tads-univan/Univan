using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using SharedContracts.Events;
using Univan.Application.Abstractions.Messaging;

namespace Univan.Infrastructure.Messaging
{
    public class MessageSender : IMessageSender
    {
        private readonly IPublishEndpoint _publish;
        private readonly ILogger<MessageSender> _logger;
        public MessageSender(IPublishEndpoint publish, ILogger<MessageSender> logger)
        {
            _publish = publish;
            _logger = logger;
        }
        public async Task SendEvent(BaseUnivanEvent eventMessage)
        {
            string routingKey = eventMessage.GetType().Name;
            await _publish.Publish(eventMessage, ev => ev.SetRoutingKey(routingKey));
        }
    }
}
