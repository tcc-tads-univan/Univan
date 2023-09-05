using FluentResults;
using MediatR;
using Univan.Application.Contracts.Driver;

namespace Univan.Application.Services.Driver.Queries.GetVehicleById
{
    public class GetVehicleByIdQuery : IRequest<Result<VehicleResult>>
    {
        public GetVehicleByIdQuery(int driverId, int vehicleId)
        {
            DriverId = driverId;
            VehicleId = vehicleId;
        }

        public int DriverId { get; set; }
        public int VehicleId { get; set; }
    }
}
