using FluentValidation;
using Univan.Application.Services.Common;

namespace Univan.Application.Services.Student.Command.UpdateRating
{
    public class UpdateStudentRatingCommandValidator : UserRatingUpdateCommandValidator<UpdateStudentRatingCommand>
    {
        public UpdateStudentRatingCommandValidator()
        {
            RuleFor(r => r.StudentId)
                .GreaterThan(0)
                .NotEmpty();
        }
    }
}
