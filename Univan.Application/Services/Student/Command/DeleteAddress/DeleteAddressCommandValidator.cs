using FluentValidation;

namespace Univan.Application.Services.Student.Command.DeleteAddress
{
    public class DeleteAddressCommandValidator : AbstractValidator<DeleteAddressCommand>
    {
        public DeleteAddressCommandValidator()
        {
            RuleFor(a => a.AddressId)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(a => a.StudentId)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
