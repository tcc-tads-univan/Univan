using FluentResults;
using MediatR;
using Univan.Application.Validation;
using Univan.Domain.Repositories;

namespace Univan.Application.Services.Driver.Command.DeleteVehicle
{
    public class DeleteVehicleCommandHandler : IRequestHandler<DeleteVehicleCommand, Result>
    {
        private readonly IDriverRepository _driverRepository;
        public DeleteVehicleCommandHandler(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }
        public async Task<Result> Handle(DeleteVehicleCommand request, CancellationToken cancellationToken)
        {
            var driver = await _driverRepository.GetUserById(request.DriverId);
            
            if (driver is null)
            {
                return Result.Fail(ValidationErrors.Driver.NotFound);
            }

            if (driver.VehicleId == null || driver.VehicleId != request.VehicleId)
            {
                return Result.Fail(ValidationErrors.Vehicle.NotFound);
            }

            var driverSubscriptions = await _driverRepository.GetSubscriptions(request.DriverId);

            if (driverSubscriptions.Any())
            {
                return Result.Fail(ValidationErrors.Driver.VehicleDeleteConflit);
            }

            await _driverRepository.DeleteDriverVehicle(request.DriverId, request.VehicleId);
            return Result.Ok();
        }
    }
}
