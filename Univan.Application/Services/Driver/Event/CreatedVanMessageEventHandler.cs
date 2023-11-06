using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using Univan.Domain.Events;

namespace Univan.Application.Services.Driver.Event
{
    public class CreatedVanMessageEventHandler : INotificationHandler<CreatedVanMessage>
    {
        private readonly IPublishEndpoint _publish;
        private readonly ILogger<CreatedVanMessageEventHandler> _logger;
        public async Task Handle(CreatedVanMessage notification, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            /*
            var eventMessage = new AcceptedSubscriptionEvent()
            {
                DriverId = notification.DriverId,
                StudentId = notification.StudentId
            };
            */

            //await _publish.Publish(eventMessage, ev => ev.SetRoutingKey(eventMessage.GetType().Name));
            _logger.LogInformation("CreatedVanMessage SENT!");
        }
    }
}
