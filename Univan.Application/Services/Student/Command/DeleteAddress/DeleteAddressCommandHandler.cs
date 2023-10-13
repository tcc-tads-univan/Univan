using FluentResults;
using MediatR;
using Univan.Application.Validation;
using Univan.Domain.Repositories;

namespace Univan.Application.Services.Student.Command.DeleteAddress
{
    public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand, Result>
    {
        private readonly IStudentRepository _studentRepository;
        public DeleteAddressCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<Result> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.GetUserById(request.StudentId);

            if (student is null)
            {
                return Result.Fail(ValidationErrors.Student.NotFound);
            }

            var subscription = await _studentRepository.GetSubscription(request.StudentId);

            if (subscription is not null)
            {
                return Result.Fail(ValidationErrors.Student.AddressDeleteConflit);
            }

            await _studentRepository.DeleteStudentAddress(request.StudentId, request.AddressId);
            return Result.Ok();
        }
    }
}
