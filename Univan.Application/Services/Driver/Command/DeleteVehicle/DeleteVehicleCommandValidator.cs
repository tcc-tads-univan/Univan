using FluentValidation;

namespace Univan.Application.Services.Driver.Command.DeleteVehicle
{
    public class DeleteVehicleCommandValidator : AbstractValidator<DeleteVehicleCommand>
    {
        public DeleteVehicleCommandValidator()
        {
            RuleFor(v => v.DriverId).NotEmpty()
                .GreaterThan(0);

            RuleFor(v => v.VehicleId).NotEmpty()
                .GreaterThan(0);
        }
    }
}
