using FluentResults;
using MediatR;

namespace Univan.Application.Services.Subscriber.Command.DeclineSubscription
{
    public class DeclineSubscriptionCommandHandler : IRequestHandler<DeclineSubscriptionCommand, Result>
    {
        public Task<Result> Handle(DeclineSubscriptionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
