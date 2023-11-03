using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using SharedContracts;
using Univan.Domain.Events;

namespace Univan.Application.Services.Common.Event
{
    public class CreatedUserMessageHandler : INotificationHandler<CreatedUserMessage>
    {
        private readonly IPublishEndpoint _publish;
        private readonly ILogger<CreatedUserMessageHandler> _logger;
        public CreatedUserMessageHandler(IPublishEndpoint publish, ILogger<CreatedUserMessageHandler> logger)
        {
            _publish = publish;
            _logger = logger;
        }

        public async Task Handle(CreatedUserMessage notification, CancellationToken cancellationToken)
        {
            var eventMessage = new CreatedUserEvent()
            {
                Email = notification.Email,
                Name = notification.Name,
                UserId = notification.UserId
            };

            await _publish.Publish(eventMessage, ev => ev.SetRoutingKey(eventMessage.GetType().Name));
            _logger.LogInformation("CreatedUserEventHandler SENT!");
        }
    }
}
