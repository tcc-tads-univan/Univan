using FluentResults;
using MediatR;

namespace Univan.Application.Services.Subscriber.Command.InviteSubscription
{
    public class InviteSubscriptionCommandHandler : IRequestHandler<InviteSubscriptionCommand, Result>
    {
        public Task<Result> Handle(InviteSubscriptionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
