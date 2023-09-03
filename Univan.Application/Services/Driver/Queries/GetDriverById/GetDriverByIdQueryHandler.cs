using FluentResults;
using MediatR;
using Univan.Application.Contracts.Driver;
using Univan.Application.Validation;
using Univan.Domain.Repositories;

namespace Univan.Application.Services.Driver.Queries.GetDriverById
{
    public class GetDriverByIdQueryHandler : IRequestHandler<GetDriverByIdQuery, Result<DriverResult>>
    {
        private readonly IDriverRepository _driverRepository;
        public GetDriverByIdQueryHandler(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        public async Task<Result<DriverResult>> Handle(GetDriverByIdQuery request, CancellationToken cancellationToken)
        {
            var driver = await _driverRepository.GetUserById(request.DriverId);

            if (driver is null)
            {
                return Result.Fail(ValidationErrors.Driver.NotFound);
            }

            var driverResult = new DriverResult()
            {
                Id = driver.Id,
                Cpf = driver.Cpf,
                Birthday = driver.Birthdate,
                Cnh = driver.Cnh,
                Email = driver.Email,
                Name = driver.Name,
                PhoneNumber = driver.PhoneNumber,
                PhotoUrl = driver.PhotoUrl,
                Rating = driver.Rating
            };

            return Result.Ok(driverResult);
        }
    }
}
