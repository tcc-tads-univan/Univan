using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Univan.Api.Contracts.Student;
using Univan.Application.Services.Student.Command.CreateStudent;

namespace Univan.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public StudentController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("{studentId}")]
        public async Task<IActionResult> GetStudentById(int studentId)
        {
            await Task.CompletedTask;
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent(CreateStudentRequest request)
        {
            var command = _mapper.Map<CreateStudentCommand>(request);
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
            {
                return StatusCode(StatusCodes.Status201Created);
            }

            //Problem Details
            return BadRequest();
        }
    }
}
