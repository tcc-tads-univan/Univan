using FluentResults;
using MediatR;
using Univan.Application.Validation;
using Univan.Domain.Entities;
using Univan.Domain.Repositories;

namespace Univan.Application.Services.Student.Command.CreateAddress
{
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, Result>
    {
        private readonly IStudentRepository _studentRepository;
        public CreateAddressCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<Result> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.GetUserById(request.StudentId);

            if(student is null)
            {
                return Result.Fail(ValidationErrors.Student.NotFound);
            }

            Address studentAddress = new Address()
            {
                GooglePlaceId = request.PlaceId,
                CompleteLineAddress = request.CompleteLineAddress
            };

            student.Address = studentAddress;

            await _studentRepository.SaveUserChanges();
            return Result.Ok();
        }
    }
}
