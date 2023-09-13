using FluentResults;
using MediatR;
using Univan.Application.Contracts.Driver;
using Univan.Domain.Repositories;
using Univan.Application.Validation;

namespace Univan.Application.Services.Driver.Queries.GetDriverBasicInfosById
{
    public class GetDriverBasicInfosByIdQueryHandler : IRequestHandler<GetDriverBasicInfosByIdQuery, Result<DriverBasicResult>>
    {
        private readonly IDriverRepository _driverRepository;
        public GetDriverBasicInfosByIdQueryHandler(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }
        public async Task<Result<DriverBasicResult>> Handle(GetDriverBasicInfosByIdQuery request, CancellationToken cancellationToken)
        {
            var driver = await _driverRepository.GetDriverBasicInfo(request.DriverId);

            if (driver is null)
            {
                return Result.Fail(ValidationErrors.Driver.DriverNotFound);
            }

            var driverResult = new DriverBasicResult()
            {
                Name = driver.Name,
                PhoneNumber = driver.PhoneNumber,
                PhotoUrl = driver.PhotoUrl,
                Rating = driver.Rating,
                VehiclePlate = driver.Vehicle?.Plate ?? String.Empty
            };

            return Result.Ok(driverResult);
        }
    }
}
