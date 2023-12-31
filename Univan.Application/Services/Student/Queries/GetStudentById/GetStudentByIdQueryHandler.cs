﻿using FluentResults;
using MediatR;
using Univan.Application.Contracts.Student;
using Univan.Application.Validation;
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
            var student = await _studentRepository.GetUserById(request.StudentId);

            if(student is null)
            {
                return Result.Fail(ValidationErrors.Student.NotFound);
            }

            StudentResult result = new StudentResult()
            {
                Id = student.Id,
                Birthday = student.Birthdate,
                Cpf = student.Cpf,
                Email = student.Email,
                Name = student.Name,
                PhoneNumber = student.PhoneNumber,
                PhotoUrl = student.PhotoUrl,
                Rating = student.Rating,
                AddressId = student.AddressId
            };

            return Result.Ok(result);
        }
    }
}
