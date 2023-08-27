using MediatR;
using Univan.Application.Contracts.Student;

namespace Univan.Application.Services.Student.Queries.GetStudentById
{
    public class GetStudentByIdQuery : IRequest<StudentResult>
    {
        public int StudentId { get; set; }
    }
}
