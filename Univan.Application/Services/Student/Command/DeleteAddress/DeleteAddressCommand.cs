using FluentResults;
using MediatR;

namespace Univan.Application.Services.Student.Command.DeleteAddress
{
    public class DeleteAddressCommand : IRequest<Result>
    {
        public int StudentId { get; set; }
        public int AddressId { get; set; }
    }
}
