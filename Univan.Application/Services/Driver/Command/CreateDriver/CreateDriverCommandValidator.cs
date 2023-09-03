using FluentValidation;
using Univan.Application.Services.Common;

namespace Univan.Application.Services.Driver.Command.CreateDriver
{
    public class CreateDriverCommandValidator : UserBaseCommandValidator<CreateDriverCommand>
    {
        public CreateDriverCommandValidator()
        {
            RuleFor(s => s.Cnh).NotEmpty()
                .MaximumLength(11)
                .Matches(@"^\d");
        }
    }
}
