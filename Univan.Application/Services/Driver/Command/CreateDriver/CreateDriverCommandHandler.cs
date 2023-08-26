using FluentResults;
using MediatR;

namespace Univan.Application.Services.Driver.Command.CreateDriver
{
    public class CreateDriverCommandHandler : IRequestHandler<CreateDriverCommand, Result>
    {
        public Task<Result> Handle(CreateDriverCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
