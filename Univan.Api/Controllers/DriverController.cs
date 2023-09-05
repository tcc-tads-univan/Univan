using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Univan.Api.Contracts.Driver;
using Univan.Application.Services.Driver.Command.CreateDriver;
using Univan.Application.Services.Driver.Command.CreateVehicle;
using Univan.Application.Services.Driver.Queries.GetDriverById;
using Univan.Application.Services.Driver.Queries.GetVehicleById;

namespace Univan.Api.Controllers
{
    [Route("api/[controller]")]
    public class DriverController : BaseController
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
            var query = new GetDriverByIdQuery(driverId);
            var result = await _mediator.Send(query);
            if (result.IsSuccess)
            {
                return Ok(_mapper.Map<DriverResponse>(result.Value));
            }

            return ProblemDetails(result.Errors);
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

            return ProblemDetails(result.Errors);
        }

        [HttpPost]
        [Route("{driverId}/vehicle")]
        public async Task<IActionResult> CreateDriverVehicle(int driverId, CreateVehicleRequest request)
        {
            var command = _mapper.Map<CreateVehicleCommand>(request);
            command.DriverId = driverId;
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
            {
                return StatusCode(StatusCodes.Status201Created);
            }

            return ProblemDetails(result.Errors);
        } 
        
        [HttpGet]
        [Route("{driverId}/vehicle/{vehicleId}")]
        public async Task<IActionResult> CreateDriverVehicle(int driverId, int vehicleId)
        {
            var query = new GetVehicleByIdQuery(driverId, vehicleId);
            var result = await _mediator.Send(query);
            if (result.IsSuccess)
            {
                return Ok(_mapper.Map<VehicleResponse>(result.Value));
            }

            return ProblemDetails(result.Errors);
        }
    }
}
