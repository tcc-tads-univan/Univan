using FluentResults;
using MediatR;
using Univan.Application.Contracts.Student;

namespace Univan.Application.Services.Student.Queries.GetStudentById
{
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, Result<StudentResult>>
    {
        public Task<Result<StudentResult>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
