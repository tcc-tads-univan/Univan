using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using SharedContracts;
using Univan.Domain.Events;

namespace Univan.Application.Services.Subscriber.Event
{
    public class AcceptedSubscriptionMessageHandler : INotificationHandler<AcceptedSubscriptionMessage>
    {
        private readonly IPublishEndpoint _publish;
        private readonly ILogger<AcceptedSubscriptionMessageHandler> _logger;
        public AcceptedSubscriptionMessageHandler(IPublishEndpoint publish, ILogger<AcceptedSubscriptionMessageHandler> logger)
        {
            _publish = publish;
            _logger = logger;
        }
        public async Task Handle(AcceptedSubscriptionMessage notification, CancellationToken cancellationToken)
        {
            var eventMessage = new AcceptedSubscriptionEvent()
            {
                DriverId = notification.DriverId,
                StudentId = notification.StudentId
            };

            await _publish.Publish(eventMessage, ev => ev.SetRoutingKey(eventMessage.GetType().Name));
            _logger.LogInformation("AcceptedSubscriptionEvent SENT!");
        }
    }
}
