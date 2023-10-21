using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using Univan.Domain.Events;

namespace Univan.Application.Services.Subscriber.Event.DeclineSubscription
{
    public class DeclinedSubscriptionEventHandler : INotificationHandler<DeclinedSubscriptionEvent>
    {
        private readonly IPublishEndpoint _publish;
        private readonly ILogger<DeclinedSubscriptionEventHandler> _logger;

        public DeclinedSubscriptionEventHandler(IPublishEndpoint publish, ILogger<DeclinedSubscriptionEventHandler> logger)
        {
            _publish = publish;
            _logger = logger;
        }

        public async Task Handle(DeclinedSubscriptionEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("DeclinedSubscriptionEvent created!");
            await _publish.Publish(notification);
            _logger.LogInformation("DeclinedSubscriptionEvent send!");
        }
    }
}
