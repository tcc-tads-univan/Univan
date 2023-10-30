using MediatR;
using Microsoft.Extensions.Logging;
using SharedContracts;
using Univan.Application.Abstractions.Messaging;
using Univan.Domain.Events;

namespace Univan.Application.Services.Common.Event
{
    public class CreatedUserMessageHandler : INotificationHandler<CreatedUserMessage>
    {
        private readonly IMessageSender _messageSender;
        private readonly ILogger<CreatedUserMessageHandler> _logger;
        public CreatedUserMessageHandler(IMessageSender messageSender, ILogger<CreatedUserMessageHandler> logger)
        {
            _messageSender = messageSender;
            _logger = logger;
        }

        public async Task Handle(CreatedUserMessage notification, CancellationToken cancellationToken)
        {
            CreatedUserEvent eventMessage = new CreatedUserEvent()
            {
                Email = notification.Email,
                Name = notification.Name,
                UserId = notification.UserId
            };
            await _messageSender.SendEvent(eventMessage);
            _logger.LogInformation("CreatedUserEventHandler SENT!");
        }
    }
}
