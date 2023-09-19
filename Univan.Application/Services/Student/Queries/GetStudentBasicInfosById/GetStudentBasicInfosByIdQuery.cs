using FluentResults;
using MediatR;
using Univan.Application.Contracts.Student;

namespace Univan.Application.Services.Student.Queries.GetStudentBasicInfosById
{
    public class GetStudentBasicInfosByIdQuery : IRequest<Result<StudentBasicResult>>
    {
        public int StudentId { get; set; }
        public GetStudentBasicInfosByIdQuery(int studentId)
        {
            StudentId = studentId;
        }
    }
}
