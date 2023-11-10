using FluentValidation;

namespace Univan.Application.Services.Common
{
    public class UserRatingUpdateCommandValidator<T> : AbstractValidator<T> where T : UserRatingUpdateCommand
    {
        public UserRatingUpdateCommandValidator()
        {
            RuleFor(r => r.Rating)
                .GreaterThan(0)
                .NotEmpty();
        }
    }
}
