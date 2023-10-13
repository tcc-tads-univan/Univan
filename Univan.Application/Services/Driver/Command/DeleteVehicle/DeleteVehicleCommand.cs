using FluentResults;
using MediatR;

namespace Univan.Application.Services.Driver.Command.DeleteVehicle
{
    public class DeleteVehicleCommand : IRequest<Result>
    {
        public DeleteVehicleCommand(int driverId, int vehicleId)
        {
            DriverId = driverId;
            VehicleId = vehicleId;
        }
        public int DriverId { get; set; }
        public int VehicleId { get; set; }
    }
}
