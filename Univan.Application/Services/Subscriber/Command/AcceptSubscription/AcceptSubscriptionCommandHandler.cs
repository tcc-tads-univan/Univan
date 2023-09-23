using FluentResults;
using MediatR;

namespace Univan.Application.Services.Subscriber.Command.AcceptSubscription
{
    public class AcceptSubscriptionCommandHandler : IRequestHandler<AcceptSubscriptionCommand, Result>
    {
        public Task<Result> Handle(AcceptSubscriptionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
