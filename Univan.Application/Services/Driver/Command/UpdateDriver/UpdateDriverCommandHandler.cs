using FluentResults;
using MediatR;
using Univan.Application.Abstractions.Security;
using Univan.Application.Abstractions.Storage;
using Univan.Application.Validation;
using Univan.Domain.Repositories;

namespace Univan.Application.Services.Driver.Command.UpdateDriver
{
    public class UpdateDriverCommandHandler : IRequestHandler<UpdateDriverCommand, Result>
    {
        private readonly IDriverRepository _driverRepository;
        private readonly IPasswordManager _passwordManager;
        private readonly IBlobService _blobService;

        public UpdateDriverCommandHandler(IPasswordManager passwordManager, IBlobService blobService, IDriverRepository driverRepository)
        {
            _passwordManager = passwordManager;
            _driverRepository = driverRepository;
            _blobService = blobService;
        }

        public async Task<Result> Handle(UpdateDriverCommand request, CancellationToken cancellationToken)
        {
            var driver = await _driverRepository.GetUserById(request.Id);

            if(driver is null)
            {
                return Result.Fail(ValidationErrors.Driver.NotFound);
            }

            if (!String.IsNullOrEmpty(request.Password))
            {
                driver.Password = _passwordManager.HashPassword(request.Password);
            }

            if (request.Photo != Stream.Null)
            {
                driver.PhotoUrl = await _blobService.GetUrlProfilePicture(request.Name, request.Photo);
            }

            driver.Cnh = request.Cnh;
            driver.Name = request.Name;
            driver.Birthdate = request.Birthdate;
            driver.PhoneNumber = request.PhoneNumber;

            await _driverRepository.SaveUserChanges();
            return Result.Ok();
        }
    }
}
