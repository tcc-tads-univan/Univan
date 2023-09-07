using FluentResults;
using MediatR;
using Univan.Application.Validation;
using Univan.Domain.Entities;
using Univan.Domain.Repositories;

namespace Univan.Application.Services.Driver.Command.CreateVehicle
{
    public class CreateVehicleCommandHandler : IRequestHandler<CreateVehicleCommand, Result>
    {
        private readonly IDriverRepository _driverRepository;
        public CreateVehicleCommandHandler(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        public async Task<Result> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
        {
            var driver = await _driverRepository.GetUserById(request.DriverId);

            if(driver is null)
            {
                return Result.Fail(ValidationErrors.Driver.DriverNotFound);
            }

            Vehicle vehicle = new Vehicle()
            {
                Model = request.Model,
                FabricationYear = request.FabricationYear,
                Plate = request.Plate,
                Seats = request.Seats
            };

            driver.Vehicle = vehicle;

            await _driverRepository.SaveUserChanges();

            return Result.Ok();
        }
    }
}
