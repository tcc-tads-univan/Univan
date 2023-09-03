using FluentResults;
using MediatR;

namespace Univan.Application.Services.Driver.Command.CreateVehicle
{
    public class CreateVehicleCommand : IRequest<Result>
    {
        public string Plate { get; set; }
        public string Model { get; set; }
        public int FabricationYear { get; set; }
        public int Seats { get; set; }
    }
}
