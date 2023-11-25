using FluentResults;
using MediatR;
using Univan.Application.Validation;
using Univan.Domain.Entities;
using Univan.Domain.Events;
using Univan.Domain.Repositories;

namespace Univan.Application.Services.Driver.Command.CreateVehicle
{
    public class CreateVehicleCommandHandler : IRequestHandler<CreateVehicleCommand, Result>
    {
        private readonly IDriverRepository _driverRepository;
        private readonly IMediator _mediator;

        public CreateVehicleCommandHandler(IDriverRepository driverRepository, IMediator mediator)
        {
            _driverRepository = driverRepository;
            _mediator = mediator;
        }

        public async Task<Result> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
        {
            var driver = await _driverRepository.GetUserById(request.DriverId);

            if(driver is null)
            {
                return Result.Fail(ValidationErrors.Driver.NotFound);
            }

            Vehicle vehicle = new Vehicle()
            {
                Model = request.Model,
                FabricationYear = request.FabricationYear,
                Plate = request.Plate,
                Seats = request.Seats,
                GaragePlaceId = request.GarageAddress
            };

            driver.Vehicle = vehicle;

            await _driverRepository.SaveUserChanges();
            
            await _mediator.Publish(new UserAddressEvent(driver.Id, relatedTo: null, vehicle.GaragePlaceId));

            return Result.Ok();
        }
    }
}
