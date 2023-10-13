using FluentResults;
using MediatR;

namespace Univan.Application.Services.Student.Command.CreateAddress
{
    public class CreateAddressCommand : IRequest<Result>
    {
        public int StudentId { get; set; }
        public string CompleteLineAddress { get; set; }
        public string PlaceId { get; set; }
    }
}
