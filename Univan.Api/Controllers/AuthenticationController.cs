using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Univan.Api.Contracts.Authentication;
using Univan.Application.Services.Authentication.Command.Login;

namespace Univan.Api.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public AuthenticationController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var command = _mapper.Map<LoginCommand>(request);
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
            {
                var login = _mapper.Map<LoginResponse>(result.Value);
                return Ok(login);
            }

            return ProblemDetails(result.Errors);
        }
    }
}
