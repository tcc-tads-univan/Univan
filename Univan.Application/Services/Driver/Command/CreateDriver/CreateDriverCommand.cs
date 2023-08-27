using FluentResults;
using MediatR;
using Univan.Application.Services.Common;

namespace Univan.Application.Services.Driver.Command.CreateDriver
{
    public class CreateDriverCommand : UserBaseCommand, IRequest<Result>
    {
        public string Cnh { get; set; }
    }
}
