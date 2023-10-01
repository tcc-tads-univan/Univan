using FluentResults;
using MediatR;
using Univan.Application.Contracts.Authentication;

namespace Univan.Application.Services.Authentication.Command.Login
{
    public class LoginCommand : IRequest<Result<AuthenticationResult>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
