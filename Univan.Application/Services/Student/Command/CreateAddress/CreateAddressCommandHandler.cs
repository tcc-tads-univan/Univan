using FluentResults;
using MediatR;
using Univan.Application.Validation;
using Univan.Domain.Entities;
using Univan.Domain.Events;
using Univan.Domain.Repositories;

namespace Univan.Application.Services.Student.Command.CreateAddress
{
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, Result>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMediator _mediator;
        public CreateAddressCommandHandler(IStudentRepository studentRepository, IMediator mediator)
        {
            _studentRepository = studentRepository;
            _mediator = mediator;
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

            await _mediator.Publish(new UserAddressEvent(student.Id, relatedTo: null, studentAddress.GooglePlaceId));

            return Result.Ok();
        }
    }
}
