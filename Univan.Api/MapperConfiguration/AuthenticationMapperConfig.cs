using Mapster;
using Microsoft.AspNetCore.Authentication;
using Univan.Api.Contracts.Authentication;
using Univan.Application.Services.Authentication.Command.Login;

namespace Univan.Api.MapperConfiguration
{
    public class AuthenticationMapperConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<LoginRequest, LoginCommand>();
            config.NewConfig<AuthenticateResult, LoginResponse>();
        }
    }
}
