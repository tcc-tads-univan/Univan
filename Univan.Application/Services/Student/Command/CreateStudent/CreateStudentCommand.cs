using FluentResults;
using MediatR;
using Univan.Application.Services.Common;

namespace Univan.Application.Services.Student.Command.CreateStudent
{
    public class CreateStudentCommand : UserBaseCommand, IRequest<Result>
    {
        public CreateStudentCommand(string name, string email, string password, string cpf, string phoneNumber, DateTime birthdate, Stream photo) 
            : base(name,email,password,cpf,phoneNumber,birthdate,photo)
        {

        }
    }
}
