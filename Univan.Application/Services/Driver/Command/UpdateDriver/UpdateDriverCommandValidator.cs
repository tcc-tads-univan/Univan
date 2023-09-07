using FluentValidation;
using Univan.Application.Services.Common;

namespace Univan.Application.Services.Driver.Command.UpdateDriver
{
    public class UpdateDriverCommandValidator : UserUpdateBaseCommandValidator<UpdateDriverCommand>
    {
        public UpdateDriverCommandValidator()
        {
            RuleFor(s => s.Cnh).NotEmpty()
                .MaximumLength(11)
                .Matches(@"^\d");
        }
    }
}
