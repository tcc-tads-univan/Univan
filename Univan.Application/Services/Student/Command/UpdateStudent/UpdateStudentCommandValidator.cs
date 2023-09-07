using FluentValidation;
using Univan.Application.Services.Common;

namespace Univan.Application.Services.Student.Command.UpdateStudent
{
    public sealed class UpdateStudentCommandValidator : UserUpdateBaseCommandValidator<UpdateStudentCommand>
    {
        public UpdateStudentCommandValidator()
        {
        }
    }
}
