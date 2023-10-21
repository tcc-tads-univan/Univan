using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using Univan.Application.Services.Subscriber.Event.AcceptSubscription;
using Univan.Domain.Events;

namespace Univan.Application.Services.Common.Event
{
    public class CreatedUserEventHandler : INotificationHandler<CreatedUserEvent>
    {
        private readonly IPublishEndpoint _publish;
        private readonly ILogger<CreatedUserEventHandler> _logger;
        public CreatedUserEventHandler(IPublishEndpoint publish, ILogger<CreatedUserEventHandler> logger)
        {
            _publish = publish;
            _logger = logger;
        }

        public async Task Handle(CreatedUserEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("CreatedUserEventHandler created!");
            await _publish.Publish(notification);
            _logger.LogInformation("CreatedUserEventHandler send!");
        }
    }
}
