using FluentResults;
using MediatR;
using Univan.Application.Contracts.Driver;

namespace Univan.Application.Services.Driver.Queries.GetDriverBasicInfosById
{
    public class GetDriverBasicInfosByIdQuery : IRequest<Result<DriverBasicResult>>
    {
        public int DriverId { get; set; }

        public GetDriverBasicInfosByIdQuery(int driverId)
        {
            DriverId = driverId;
        }

    }
}
