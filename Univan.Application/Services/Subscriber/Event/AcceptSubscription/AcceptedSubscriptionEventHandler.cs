using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using Univan.Domain.Events;

namespace Univan.Application.Services.Subscriber.Event.AcceptSubscription
{
    public class AcceptedSubscriptionEventHandler : INotificationHandler<AcceptedSubscriptionEvent>
    {
        private readonly IPublishEndpoint _publish;
        private readonly ILogger<AcceptedSubscriptionEventHandler> _logger;
        public AcceptedSubscriptionEventHandler(IPublishEndpoint publish, ILogger<AcceptedSubscriptionEventHandler> logger)
        {
            _publish = publish;
            _logger = logger;
        }
        public async Task Handle(AcceptedSubscriptionEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("AcceptedSubscriptionEvent created!");
            await _publish.Publish(notification);
            _logger.LogInformation("AcceptedSubscriptionEvent send!");
        }
    }
}
