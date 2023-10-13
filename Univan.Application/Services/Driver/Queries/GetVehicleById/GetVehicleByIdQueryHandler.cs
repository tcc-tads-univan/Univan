using FluentResults;
using MediatR;
using Univan.Application.Contracts.Driver;
using Univan.Application.Validation;
using Univan.Domain.Repositories;

namespace Univan.Application.Services.Driver.Queries.GetVehicleById
{
    public class GetVehicleByIdQueryHandler : IRequestHandler<GetVehicleByIdQuery, Result<VehicleResult>>
    {
        private readonly IDriverRepository _driverRepository;
        public GetVehicleByIdQueryHandler(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        public async Task<Result<VehicleResult>> Handle(GetVehicleByIdQuery request, CancellationToken cancellationToken)
        {
            var vehicle = await _driverRepository.GetDriverVehicle(request.DriverId, request.VehicleId);

            if(vehicle is null)
            {
                return Result.Fail(ValidationErrors.Vehicle.NotFound);
            }

            VehicleResult vehicleResult = new VehicleResult()
            {
                Id = vehicle.Id,
                FabricationYear = vehicle.FabricationYear,
                Model = vehicle.Model,
                Plate = vehicle.Plate,
                Seats = vehicle.Seats
            };

            return Result.Ok(vehicleResult);
        }
    }
}
