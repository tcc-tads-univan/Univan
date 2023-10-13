using FluentResults;
using MediatR;
using Univan.Application.Contracts.Student;
using Univan.Application.Validation;
using Univan.Domain.Repositories;

namespace Univan.Application.Services.Student.Queries.GetStudentAddressById
{
    public class GetStudentAddressByIdQueryHandler : IRequestHandler<GetStudentAddressByIdQuery, Result<StudentAddressResult>>
    {
        private readonly IStudentRepository _studentRepository;

        public GetStudentAddressByIdQueryHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<Result<StudentAddressResult>> Handle(GetStudentAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var studentsAddress = await _studentRepository.GetStudentAddress(request.StudentId, request.AddressId);

            if(studentsAddress is null)
            {
                return Result.Fail(ValidationErrors.Address.NotFound);
            }

            var addressResult = new StudentAddressResult()
            {
                CompleteLineAddress = studentsAddress.CompleteLineAddress,
                GooglePlaceId = studentsAddress.GooglePlaceId
            };

            return Result.Ok(addressResult);
        }
    }
}
