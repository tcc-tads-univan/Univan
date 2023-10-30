using MediatR;
using Microsoft.Extensions.Logging;
using SharedContracts;
using Univan.Application.Abstractions.Messaging;
using Univan.Domain.Events;

namespace Univan.Application.Services.Subscriber.Event
{
    public class AcceptedSubscriptionMessageHandler : INotificationHandler<AcceptedSubscriptionMessage>
    {
        private readonly IMessageSender _messageSender;
        private readonly ILogger<AcceptedSubscriptionMessageHandler> _logger;
        public AcceptedSubscriptionMessageHandler(IMessageSender messageSender, ILogger<AcceptedSubscriptionMessageHandler> logger)
        {
            _messageSender = messageSender;
            _logger = logger;
        }
        public async Task Handle(AcceptedSubscriptionMessage notification, CancellationToken cancellationToken)
        {
            AcceptedSubscriptionEvent eventMessage = new AcceptedSubscriptionEvent()
            {
                DriverId = notification.DriverId,
                StudentId = notification.StudentId
            };
            await _messageSender.SendEvent(eventMessage);
            _logger.LogInformation("AcceptedSubscriptionEvent SENT!");
        }
    }
}
