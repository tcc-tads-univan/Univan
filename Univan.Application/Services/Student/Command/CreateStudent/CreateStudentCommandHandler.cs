using FluentResults;
using MediatR;
using Univan.Application.Abstractions.Security;
using Univan.Application.Abstractions.Storage;
using Univan.Domain.Errors;
using Univan.Domain.Events;
using Univan.Domain.Repositories;

namespace Univan.Application.Services.Student.Command.CreateStudent
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, Result>
    {
        private readonly IPasswordManager _passwordManager;
        private readonly IStudentRepository _studentRepository;
        private readonly IBlobService _blobService;
        private readonly IMediator _mediator;
        public CreateStudentCommandHandler(IPasswordManager passwordManager, IStudentRepository studentRepository, IBlobService blobService, IMediator mediator)
        {
            _passwordManager = passwordManager;
            _studentRepository = studentRepository;
            _blobService = blobService;
            _mediator = mediator;
        }
        public async Task<Result> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            if (await _studentRepository.UserAlreadyExist(request.Cpf, request.Email))
            {
                return Result.Fail(DomainError.User.Duplicated);
            }

            var hashPassword = _passwordManager.HashPassword(request.Password);

            var photoUrl = await _blobService.GetUrlProfilePicture(request.Name, request.Photo);

            Domain.Entities.Student student = new Domain.Entities.Student()
            {
                Cpf = request.Cpf,
                Email = request.Email,
                Name = request.Name,
                PhoneNumber = request.PhoneNumber,
                Rating = 0M,
                Birthdate = request.Birthdate,
                Password = hashPassword,
                PhotoUrl = photoUrl
            };
            await _studentRepository.SaveUserAsync(student);

            await _mediator.Publish(new CreatedUserEvent(student.Id, student.Name, student.Email));

            return Result.Ok();
        }

    }
}
