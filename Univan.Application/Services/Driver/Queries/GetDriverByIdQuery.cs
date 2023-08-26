using MediatR;
using Univan.Application.Contracts.Driver;

namespace Univan.Application.Services.Driver.Queries
{
    public class GetDriverByIdQuery : IRequest<DriverResult>
    {
        public int DriverId { get; set; }
    }
}
