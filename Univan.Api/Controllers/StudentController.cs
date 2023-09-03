using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Univan.Api.Contracts.Student;
using Univan.Application.Services.Student.Command.CreateStudent;
using Univan.Application.Services.Student.Queries.GetStudentById;

namespace Univan.Api.Controllers
{
    [Route("api/[controller]")]
    public class StudentController : BaseController
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
            var query = new GetStudentByIdQuery(studentId);
            var result = await _mediator.Send(query);
            if (result.IsSuccess)
            {
                var student = _mapper.Map<StudentResponse>(result.Value);
                return Ok(student);
            }

            return ProblemDetails(result.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromForm] CreateStudentRequest request)
        {
            var command = _mapper.Map<CreateStudentCommand>(request);
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
            {
                return StatusCode(StatusCodes.Status201Created);
            }

            return ProblemDetails(result.Errors);
        }
    }
}
