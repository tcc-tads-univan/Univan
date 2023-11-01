using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using SharedContracts.Events;
using Univan.Domain.Events;

namespace Univan.Application.Services.Subscriber.Event
{
    public class InviteSubscriptionMessageHandler : INotificationHandler<InviteSubscriptionMessage>
    {
        private readonly IPublishEndpoint _publish;
        private readonly ILogger<InviteSubscriptionMessageHandler> _logger;
        public InviteSubscriptionMessageHandler(IPublishEndpoint publish, ILogger<InviteSubscriptionMessageHandler> logger)
        {
            _publish = publish;
            _logger = logger;
        }

        public async Task Handle(InviteSubscriptionMessage notification, CancellationToken cancellationToken)
        {
            var eventMessage = new InvitedStudentSubscriptionEvent()
            {
                DriverId = notification.DriverId,
                StudentId = notification.StudentId,
                ExpirationDay = notification.ExpirationDay,
                MonthlyFee = notification.MonthlyFee
            };

            await _publish.Publish(eventMessage, ev => ev.SetRoutingKey(eventMessage.GetType().Name));
            _logger.LogInformation("InviteSubscriptionEvent SENT!");
        }
    }
}
