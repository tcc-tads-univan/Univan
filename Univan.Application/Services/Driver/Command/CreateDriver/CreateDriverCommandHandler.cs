using FluentResults;
using MediatR;
using Univan.Application.Abstractions.Security;
using Univan.Application.Abstractions.Storage;
using Univan.Domain.Errors;
using Univan.Domain.Events;
using Univan.Domain.Repositories;

namespace Univan.Application.Services.Driver.Command.CreateDriver
{
    public class CreateDriverCommandHandler : IRequestHandler<CreateDriverCommand, Result>
    {
        private readonly IPasswordManager _passwordManager;
        private readonly IDriverRepository _driverRepository;
        private readonly IBlobService _blobService;
        private readonly IMediator _mediator;

        public CreateDriverCommandHandler(IPasswordManager passwordManager, IBlobService blobService,IDriverRepository driverRepository, IMediator mediator)
        {
            _passwordManager = passwordManager;
            _driverRepository = driverRepository;
            _blobService = blobService;
            _mediator = mediator;
        }

        public async Task<Result> Handle(CreateDriverCommand request, CancellationToken cancellationToken)
        {
            if(await _driverRepository.UserAlreadyExist(request.Cpf, request.Email))
            {
                return Result.Fail(DomainError.User.Duplicated);
            }

            var hashPassword = _passwordManager.HashPassword(request.Password);

            var photoUrl = await _blobService.GetUrlProfilePicture(request.Name, request.Photo);

            Domain.Entities.Driver driver = new Domain.Entities.Driver()
            {
                Cpf = request.Cpf,
                Email = request.Email,
                Name = request.Name,
                PhoneNumber = request.PhoneNumber,
                Rating = 0M,
                Birthdate = request.Birthdate,
                Password = hashPassword,
                PhotoUrl = photoUrl,
                Cnh = request.Cnh
            };

            await _driverRepository.SaveUserAsync(driver);

            await _mediator.Publish(new CreatedUserEvent(driver.Id, driver.Name, driver.Email));

            return Result.Ok();
        }
    }
}
