using FluentResults;
using MediatR;
using Univan.Application.Contracts.Student;
using Univan.Application.Validation;
using Univan.Domain.Repositories;

namespace Univan.Application.Services.Student.Queries.GetStudentBasicInfosById
{
    public class GetStudentBasicInfosByIdQueryHandler : IRequestHandler<GetStudentBasicInfosByIdQuery, Result<StudentBasicResult>>
    {
        private readonly IStudentRepository _studentRepository;

        public GetStudentBasicInfosByIdQueryHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Result<StudentBasicResult>> Handle(GetStudentBasicInfosByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.GetStudentBasicInfo(request.StudentId);

            if(student is null)
            {
                return Result.Fail(ValidationErrors.Student.NotFound);
            }

            var studentResult = new StudentBasicResult()
            {
                Name = student.Name,
                PhoneNumber = student.PhoneNumber,
                PhotoUrl = student.PhotoUrl,
                Rating = student.Rating,
                LineAddress = ""
            };

            return Result.Ok(studentResult);
        }
    }
}
