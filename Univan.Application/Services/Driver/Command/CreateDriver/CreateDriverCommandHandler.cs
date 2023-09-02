using FluentResults;
using MediatR;
using Univan.Application.Abstractions.Security;
using Univan.Application.Abstractions.Storage;
using Univan.Domain.Repositories;

namespace Univan.Application.Services.Driver.Command.CreateDriver
{
    public class CreateDriverCommandHandler : IRequestHandler<CreateDriverCommand, Result>
    {
        private readonly IPasswordManager _passwordManager;
        private readonly IDriverRepository _driverRepository;
        private readonly IBlobService _blobService;

        public CreateDriverCommandHandler(IPasswordManager passwordManager, IBlobService blobService,IDriverRepository driverRepository)
        {
            _passwordManager = passwordManager;
            _driverRepository = driverRepository;
            _blobService = blobService;
        }

        public async Task<Result> Handle(CreateDriverCommand request, CancellationToken cancellationToken)
        {
            var hashPassword = _passwordManager.HashPassword(request.Password);

            var photoUrl = await _blobService.GetUrlProfilePicture(request.Name, request.Photo);

            //REGRAS DE NEGÓCIO EMAILALREADYEXIST, CPFALREADYEXIST

            Domain.Entities.Driver driver = new Domain.Entities.Driver()
            {
                Cpf = request.Cpf,
                Email = request.Email,
                Name = request.Name,
                PhoneNumber = request.PhoneNumber,
                Rating = 0M,
                Birthday = request.Birthday,
                Password = hashPassword,
                PhotoUrl = photoUrl,
                Cnh = request.Cnh
            };

            await _driverRepository.SaveUserAsync(driver);

            return Result.Ok();
        }
    }
}
