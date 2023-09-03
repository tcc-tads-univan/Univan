using FluentResults;
using MediatR;

namespace Univan.Application.Services.Driver.Command.CreateVehicle
{
    public class CreateVehicleCommandHandler : IRequestHandler<CreateVehicleCommand, Result>
    {
        public Task<Result> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
