using FluentResults;
using MediatR;

namespace Univan.Application.Services.Student.Command.UpdateStudent
{
    public class UpdateStudentCommand : IRequest<Result>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birthday { get; set; }
    }
}
