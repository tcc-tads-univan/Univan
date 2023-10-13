using FluentValidation;

namespace Univan.Application.Services.Student.Command.CreateAddress
{
    public class CreateAddressCommandValidator : AbstractValidator<CreateAddressCommand>
    {
        public CreateAddressCommandValidator()
        {
            RuleFor(a => a.CompleteLineAddress)
                .NotEmpty()
                .MaximumLength(500);

            RuleFor(a => a.PlaceId)
                .NotEmpty()
                .MaximumLength(120);
        }
    }
}
