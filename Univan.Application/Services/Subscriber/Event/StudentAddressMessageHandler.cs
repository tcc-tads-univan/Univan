using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using Univan.Domain.Events;

namespace Univan.Application.Services.Subscriber.Event
{
    public class StudentAddressMessageHandler : INotificationHandler<StudentAddressEvent>
    {
        private readonly IPublishEndpoint _publish;
        private readonly ILogger<StudentAddressMessageHandler> _logger;

        public async Task Handle(StudentAddressEvent notification, CancellationToken cancellationToken)
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
            _logger.LogInformation("StudentAddressMessage SENT!");
        }
    }
}
