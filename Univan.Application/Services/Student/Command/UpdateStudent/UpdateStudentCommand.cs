using FluentResults;
using MediatR;
using Univan.Application.Services.Common;

namespace Univan.Application.Services.Student.Command.UpdateStudent
{
    public class UpdateStudentCommand : UserUpdateBaseCommand, IRequest<Result>
    {
        public UpdateStudentCommand(int id, string name, string password, string phoneNumber, DateTime birthdate, Stream photo) 
            : base(id, name, password, phoneNumber, birthdate, photo)
        {
           
        }
    }
}
