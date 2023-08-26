using FluentResults;
using MediatR;

namespace Univan.Application.Services.Student.Command.CreateStudent
{
    public class CreateStudentCommand : IRequest<Result>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Cpf { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birthday { get; set; }
    }
}
