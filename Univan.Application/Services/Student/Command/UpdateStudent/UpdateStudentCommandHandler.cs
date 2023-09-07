using FluentResults;
using MediatR;
using Univan.Application.Abstractions.Security;
using Univan.Application.Abstractions.Storage;
using Univan.Application.Validation;
using Univan.Domain.Repositories;

namespace Univan.Application.Services.Student.Command.UpdateStudent
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, Result>
    {
        private readonly IPasswordManager _passwordManager;
        private readonly IStudentRepository _studentRepository;
        private readonly IBlobService _blobService;

        public UpdateStudentCommandHandler(IPasswordManager passwordManager, IStudentRepository studentRepository, IBlobService blobService)
        {
            _passwordManager = passwordManager;
            _studentRepository = studentRepository;
            _blobService = blobService;
        }
        public async Task<Result> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.GetUserById(2);
            
            if(student is null)
            {
                return Result.Fail(ValidationErrors.Student.NotFound);
            }

            if (!String.IsNullOrEmpty(request.Password))
            {
                student.Password = _passwordManager.HashPassword(request.Password);
            }

            if(request.Photo != Stream.Null)
            {
                student.PhotoUrl = await _blobService.GetUrlProfilePicture(request.Name, request.Photo);
            }

            student.Name = request.Name;
            student.Birthdate = request.Birthdate;
            student.PhoneNumber = request.PhoneNumber;

            await _studentRepository.SaveUserChanges();
            return Result.Ok();
        }   
    }
}
