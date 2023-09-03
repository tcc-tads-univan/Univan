using FluentResults;
using MediatR;
using Univan.Application.Contracts.Driver;

namespace Univan.Application.Services.Driver.Queries.GetDriverById
{
    public class GetDriverByIdQuery : IRequest<Result<DriverResult>>
    {
        public GetDriverByIdQuery(int driverId)
        {
            DriverId = driverId;
        }

        public int DriverId { get; set; }
    }
}
