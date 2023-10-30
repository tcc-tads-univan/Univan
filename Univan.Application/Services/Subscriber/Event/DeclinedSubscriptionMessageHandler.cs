using MediatR;
using Microsoft.Extensions.Logging;
using SharedContracts;
using Univan.Application.Abstractions.Messaging;
using Univan.Domain.Events;

namespace Univan.Application.Services.Subscriber.Event
{
    public class DeclinedSubscriptionMessageHandler : INotificationHandler<DeclinedSubscriptionMessage>
    {
        private readonly IMessageSender _messageSender;
        private readonly ILogger<DeclinedSubscriptionMessageHandler> _logger;

        public DeclinedSubscriptionMessageHandler(IMessageSender messageSender, ILogger<DeclinedSubscriptionMessageHandler> logger)
        {
            _messageSender = messageSender;
            _logger = logger;
        }

        public async Task Handle(DeclinedSubscriptionMessage notification, CancellationToken cancellationToken)
        {
            DeclinedSubscriptionEvent eventMessage = new DeclinedSubscriptionEvent()
            {
                DriverId = notification.DriverId,
                StudentId = notification.StudentId
            };
            await _messageSender.SendEvent(eventMessage);
            _logger.LogInformation("DeclinedSubscriptionEvent SENT!");
        }
    }
}
