using FluentResults;
using MediatR;
using Univan.Application.Services.Common;

namespace Univan.Application.Services.Driver.Command.UpdateRating
{
    public class UpdateDriverRatingCommand : UserRatingUpdateCommand, IRequest<Result>
    {
        public UpdateDriverRatingCommand(int driverId, decimal rating) : base(rating)
        {
            DriverId = driverId;
        }

        public int DriverId { get; set; }
    }
}
