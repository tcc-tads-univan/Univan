using FluentResults;
using MediatR;
using Univan.Application.Abstractions.Security;
using Univan.Application.Abstractions.Storage;
using Univan.Domain.Repositories;

namespace Univan.Application.Services.Student.Command.CreateStudent
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, Result>
    {
        private readonly IPasswordManager _passwordManager;
        private readonly IStudentRepository _studentRepository;
        private readonly IBlobService _blobService;
        public CreateStudentCommandHandler(IPasswordManager passwordManager, IStudentRepository studentRepository, IBlobService blobService)
        {
            _passwordManager = passwordManager;
            _studentRepository = studentRepository;
            _blobService = blobService;
        }
        public async Task<Result> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var hashPassword = _passwordManager.HashPassword(request.Password);

            var photoUrl = await _blobService.UploadImage(request.Name, request.Photo);

            Domain.Entities.Student student = new Domain.Entities.Student()
            {
                Cpf = request.Cpf,
                Email = request.Email,
                Name = request.Name,
                PhoneNumber = request.PhoneNumber,
                Rating = 0M,
                Birthday = request.Birthday,
                Password = hashPassword,
                PhotoUrl = photoUrl
            };

            await _studentRepository.SaveStudent(student);

            return Result.Ok();
        }
    }
}
