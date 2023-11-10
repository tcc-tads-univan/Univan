using FluentValidation;
using Univan.Application.Services.Common;

namespace Univan.Application.Services.Driver.Command.UpdateRating
{
    public class UpdateDriverRatingCommandValidator : UserRatingUpdateCommandValidator<UpdateDriverRatingCommand>
    {
        public UpdateDriverRatingCommandValidator()
        {
            RuleFor(r => r.DriverId)
                .GreaterThan(0)
                .NotEmpty();
        }
    }
}
