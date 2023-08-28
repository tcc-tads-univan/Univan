using FluentValidation;

namespace Univan.Application.Services.Common
{
    public class UserBaseCommandValidator<T> : AbstractValidator<T> where T : UserBaseCommand
    {
        public UserBaseCommandValidator()
        {
            RuleFor(u => u.Name).NotEmpty()
                .MaximumLength(120);

            RuleFor(u => u.Email).EmailAddress();

            RuleFor(u => u.PhoneNumber).NotEmpty();

            RuleFor(u => u.Cpf).NotEmpty()
                .MaximumLength(11)
                .Matches(@"^\d$");
                

            RuleFor(u => u.Birthday).NotEmpty()
                .GreaterThan(DateTime.MinValue)
                .LessThan(DateTime.Now);

            RuleFor(u => u.Password).NotEmpty();
        }
    }
}
