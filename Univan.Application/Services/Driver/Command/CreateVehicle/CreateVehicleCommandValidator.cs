using FluentValidation;

namespace Univan.Application.Services.Driver.Command.CreateVehicle
{
    public class CreateVehicleCommandValidator : AbstractValidator<CreateVehicleCommand>
    {
        public CreateVehicleCommandValidator()
        {
            RuleFor(v => v.Plate).NotEmpty();
         
            RuleFor(v => v.Model).NotEmpty();

            RuleFor(v => v.GarageAddress).NotEmpty();
            
            RuleFor(v => v.FabricationYear)
                .NotEmpty()
                .GreaterThan(1980);

            RuleFor(v => v.Seats)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
