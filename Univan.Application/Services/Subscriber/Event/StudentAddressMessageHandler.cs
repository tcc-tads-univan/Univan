using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using SharedContracts.Events;
using System.Net.Mime;
using Univan.Domain.Events;

namespace Univan.Application.Services.Subscriber.Event
{
    public class StudentAddressMessageHandler : INotificationHandler<UserAddressEvent>
    {
        private readonly IPublishEndpoint _publish;
        private readonly ILogger<StudentAddressMessageHandler> _logger;

        public StudentAddressMessageHandler(IPublishEndpoint publish, ILogger<StudentAddressMessageHandler> logger)
        {
            _publish = publish;
            _logger = logger;
        }

        public async Task Handle(UserAddressEvent notification, CancellationToken cancellationToken)
        {
            var eventMessage = new SaveUserAddressEvent()
            {
                PlaceId = notification.PlaceId,
                RelatedTo = notification.RelatedTo,
                UserId = notification.UserId
            };

            await _publish.Publish(eventMessage, ev => 
            {
                ev.ContentType = new ContentType("application/json");
                ev.Headers.Set("__TypeId__", "saveUserAddress");
                ev.SetRoutingKey(eventMessage.GetType().Name);
            });

            _logger.LogInformation("StudentAddressMessage SENT!");
        }
    }
}
