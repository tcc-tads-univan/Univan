using FluentResults;
using MediatR;
using Univan.Domain.Repositories;

namespace Univan.Application.Services.Driver.Command.UpdateRating
{
    public class UpdateDriverRatingCommandHandler : IRequestHandler<UpdateDriverRatingCommand, Result>
    {
        private readonly IDriverRepository _driverRepository;
        public UpdateDriverRatingCommandHandler(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        public async Task<Result> Handle(UpdateDriverRatingCommand request, CancellationToken cancellationToken)
        {
            var driver = await _driverRepository.GetUserById(request.DriverId);

            driver.UpdateRating(request.Rating);

            await _driverRepository.SaveUserChanges();

            return Result.Ok();
        }
    }
}
