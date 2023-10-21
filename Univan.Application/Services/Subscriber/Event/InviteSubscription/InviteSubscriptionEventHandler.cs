using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using Univan.Application.Services.Subscriber.Event.DeclineSubscription;
using Univan.Domain.Events;

namespace Univan.Application.Services.Subscriber.Event.InviteSubscription
{
    public class InviteSubscriptionEventHandler : INotificationHandler<InviteSubscriptionEvent>
    {
        private readonly IPublishEndpoint _publish;
        private readonly ILogger<InviteSubscriptionEventHandler> _logger;
        public InviteSubscriptionEventHandler(IPublishEndpoint publish, ILogger<InviteSubscriptionEventHandler> logger)
        {
            _publish = publish;
            _logger = logger;
        }

        public async Task Handle(InviteSubscriptionEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("InviteSubscriptionEvent created!");
            await _publish.Publish(notification);
            _logger.LogInformation("InviteSubscriptionEvent send!");
        }
    }
}
