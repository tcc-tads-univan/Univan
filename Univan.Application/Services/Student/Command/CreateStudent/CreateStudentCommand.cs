using FluentResults;
using MediatR;
using Univan.Application.Services.Common;

namespace Univan.Application.Services.Student.Command.CreateStudent
{
    public class CreateStudentCommand : UserBaseCommand, IRequest<Result>
    {
        public CreateStudentCommand(string name, string email, string password, string cpf, string phoneNumber, DateTime birthday, Stream photo) 
            : base(name,email,password,cpf,phoneNumber,birthday,photo)
        {

        }
    }
}
