using FluentResults;
using MediatR;
using Univan.Application.Contracts.Student;

namespace Univan.Application.Services.Student.Queries.GetStudentById
{
    public class GetStudentByIdQuery : IRequest<Result<StudentResult>>
    {
        public GetStudentByIdQuery(int studentId)
        {
            StudentId = studentId;
        }

        public int StudentId { get; set; }
    }
}
