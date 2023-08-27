using FluentValidation;

namespace Univan.Application.Services.Driver.Command.CreateDriver
{
    public class CreateDriverCommandValidator : AbstractValidator<CreateDriverCommand>
    {
        public CreateDriverCommandValidator()
        {
            RuleFor(s => s.Cnh).NotEmpty().
                MaximumLength(11);
        }
    }
}
