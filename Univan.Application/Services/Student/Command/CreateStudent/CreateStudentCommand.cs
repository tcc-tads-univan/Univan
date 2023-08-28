using FluentResults;
using MediatR;
using Univan.Application.Services.Common;

namespace Univan.Application.Services.Student.Command.CreateStudent
{
    public class CreateStudentCommand : UserBaseCommand, IRequest<Result>
    {

    }
}
