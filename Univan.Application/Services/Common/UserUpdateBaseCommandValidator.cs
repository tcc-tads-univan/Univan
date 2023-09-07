using FluentValidation;

namespace Univan.Application.Services.Common
{
    public class UserUpdateBaseCommandValidator<T> : AbstractValidator<T> where T : UserUpdateBaseCommand
    {
        public UserUpdateBaseCommandValidator()
        {
            RuleFor(u => u.Id).NotEmpty()
                .GreaterThan(0);

            RuleFor(u => u.Name).NotEmpty()
                .MaximumLength(120);

            RuleFor(u => u.PhoneNumber).NotEmpty()
                .MaximumLength(11)
                .Matches(@"^\d");

            RuleFor(u => u.Birthdate).NotEmpty()
                .GreaterThan(DateTime.MinValue)
                .LessThan(DateTime.Now);
        }
    }
}
