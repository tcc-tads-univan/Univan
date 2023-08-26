using FluentValidation;

namespace Univan.Application.Services.Student.Command.CreateStudent
{
    public sealed class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommand>
    {
        public CreateStudentCommandValidator()
        {
            RuleFor(s => s.Name).MaximumLength(120).NotEmpty();

            RuleFor(s => s.Email).EmailAddress();

            RuleFor(s => s.PhoneNumber).NotEmpty();
        }
    }
}
