using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Univan.Api.Contracts.Driver;
using Univan.Application.Services.Driver.Command.CreateDriver;
using Univan.Application.Services.Driver.Queries;

namespace Univan.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DriverController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public DriverController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("{driverId}")]
        public async Task<IActionResult> GetDriverById(int driverId)
        {
            var command = new GetDriverByIdQuery(driverId);
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
            {
                return Ok(_mapper.Map<DriverResponse>(result.Value));
            }

            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDriver([FromForm] CreateDriverRequest request)
        {
            var command = _mapper.Map<CreateDriverCommand>(request);
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
            {
                return StatusCode(StatusCodes.Status201Created);
            }

            return BadRequest();
        }
    }
}
