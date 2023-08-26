using MediatR;
using Univan.Application.Contracts.Student;

namespace Univan.Application.Services.Student.Queries.GetStudentById
{
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, StudentResult>
    {
        public Task<StudentResult> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
