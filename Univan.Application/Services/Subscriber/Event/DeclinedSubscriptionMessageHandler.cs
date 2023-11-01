using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using SharedContracts;
using Univan.Domain.Events;

namespace Univan.Application.Services.Subscriber.Event
{
    public class DeclinedSubscriptionMessageHandler : INotificationHandler<DeclinedSubscriptionMessage>
    {
        private readonly IPublishEndpoint _publish;
        private readonly ILogger<DeclinedSubscriptionMessageHandler> _logger;

        public DeclinedSubscriptionMessageHandler(IPublishEndpoint publish, ILogger<DeclinedSubscriptionMessageHandler> logger)
        {
            _publish = publish;
            _logger = logger;
        }

        public async Task Handle(DeclinedSubscriptionMessage notification, CancellationToken cancellationToken)
        {
            var eventMessage = new DeclinedSubscriptionEvent()
            {
                DriverId = notification.DriverId,
                StudentId = notification.StudentId
            };

            await _publish.Publish(eventMessage, ev => ev.SetRoutingKey(eventMessage.GetType().Name));
            _logger.LogInformation("DeclinedSubscriptionEvent SENT!");
        }
    }
}
