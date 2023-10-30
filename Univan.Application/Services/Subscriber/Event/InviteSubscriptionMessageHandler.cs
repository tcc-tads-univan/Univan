using MediatR;
using Microsoft.Extensions.Logging;
using SharedContracts.Events;
using Univan.Application.Abstractions.Messaging;
using Univan.Domain.Events;

namespace Univan.Application.Services.Subscriber.Event
{
    public class InviteSubscriptionMessageHandler : INotificationHandler<InviteSubscriptionMessage>
    {
        private readonly IMessageSender _messageSender;
        private readonly ILogger<InviteSubscriptionMessageHandler> _logger;
        public InviteSubscriptionMessageHandler(IMessageSender messageSender, ILogger<InviteSubscriptionMessageHandler> logger)
        {
            _messageSender = messageSender;
            _logger = logger;
        }

        public async Task Handle(InviteSubscriptionMessage notification, CancellationToken cancellationToken)
        {
            InvitedStudentSubscriptionEvent eventMessage = new InvitedStudentSubscriptionEvent()
            {
                DriverId = notification.DriverId,
                StudentId = notification.StudentId,
                ExpirationDay = notification.ExpirationDay,
                MonthlyFee = notification.MonthlyFee
            };
            await _messageSender.SendEvent(eventMessage);
            _logger.LogInformation("InviteSubscriptionEvent SENT!");
        }
    }
}
