using MediatR;
using Univan.Application.Contracts.Driver;
using Univan.Domain.Repositories;

namespace Univan.Application.Services.Driver.Queries
{
    public class GetDriverIdQueryHandler : IRequestHandler<GetDriverByIdQuery, DriverResult>
    {
        public Task<DriverResult> Handle(GetDriverByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
