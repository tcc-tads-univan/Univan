using FluentResults;
using MediatR;
using Univan.Application.Abstractions.Security;
using Univan.Application.Contracts.Authentication;
using Univan.Application.Validation;
using Univan.Domain.Entities;
using Univan.Domain.Enums;
using Univan.Domain.Repositories;

namespace Univan.Application.Services.Authentication.Command.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, Result<AuthenticationResult>>
    {
        private readonly IAuthenticationRepository _authRepository;
        private readonly IPasswordManager _passwordManager;
        private readonly IJwtTokenGenerator _jwtToken;
        public LoginCommandHandler(IAuthenticationRepository authenticationRepository, IPasswordManager passwordManager, IJwtTokenGenerator jwtTokenGenerator)
        {
            _authRepository = authenticationRepository;
            _passwordManager = passwordManager;
            _jwtToken = jwtTokenGenerator;
        }

        public async Task<Result<AuthenticationResult>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            User user = await _authRepository.Login(request.Email);

            if(user is null)
            {
                return Result.Fail(ValidationErrors.Login.InvalidCredentials);
            }
            
            if(!_passwordManager.IsValidPassword(request.Password, user.Password))
            {
                return Result.Fail(ValidationErrors.Login.InvalidCredentials);
            }

            var token = _jwtToken.GenerateToken(user.Id, user.Name);

            AuthenticationResult result = new AuthenticationResult()
            {
                Name = user.Name,
                UserId = user.Id,
                UserType = GetUserType(user),
                Token = token
            };

            return Result.Ok(result);
        }

        private UserType GetUserType(User user)
        {
            return user.GetType().GetProperty("VehicleId") != null ? UserType.DRIVER : UserType.STUDENT;
        }
    }
}
