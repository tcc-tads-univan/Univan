using FluentResults;
using MediatR;
using Univan.Application.Contracts.Student;
using Univan.Domain.Repositories;

namespace Univan.Application.Services.Student.Queries.GetStudentById
{
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, Result<StudentResult>>
    {
        private readonly IStudentRepository _studentRepository;
        public GetStudentByIdQueryHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<Result<StudentResult>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.GetStudentById(request.StudentId);
            StudentResult result = new StudentResult()
            {
                Id = student.Id,
                Birthday = student.Birthday,
                Cpf = student.Cpf,
                Email = student.Email,
                Name = student.Name,
                PhoneNumber = student.PhoneNumber,
                PhotoUrl = student.PhotoUrl,
                Rating = student.Rating
            };
            return Result.Ok(result);
        }
    }
}
