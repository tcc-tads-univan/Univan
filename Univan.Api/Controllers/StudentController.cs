using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Univan.Api.Contracts.Driver;
using Univan.Api.Contracts.Student;
using Univan.Application.Services.Driver.Command.CreateVehicle;
using Univan.Application.Services.Student.Command.CreateAddress;
using Univan.Application.Services.Student.Command.CreateStudent;
using Univan.Application.Services.Student.Command.DeleteAddress;
using Univan.Application.Services.Student.Command.UpdateStudent;
using Univan.Application.Services.Student.Queries.GetStudentAddressById;
using Univan.Application.Services.Student.Queries.GetStudentBasicInfosById;
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

        [HttpGet]
        [Route("{studentId}/basic-infos")]
        public async Task<IActionResult> GetStudentBasicInfos(int studentId)
        {
            var query = new GetStudentBasicInfosByIdQuery(studentId);
            var result = await _mediator.Send(query);
            if (result.IsSuccess)
            {
                var student = _mapper.Map<StudentBasicResponse>(result.Value);
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
        
        [HttpPut]
        [Route("{studentId}")]
        public async Task<IActionResult> UpdateStudent(int studentId, [FromForm] UpdateStudentRequest request)
        {
            var command = _mapper.Map<UpdateStudentCommand>(request);
            command.Id = studentId;
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }

            return ProblemDetails(result.Errors);
        }

        [HttpPost]
        [Route("{studentId}/address")]
        public async Task<IActionResult> CreateStudentAddress(int studentId, CreateAddressRequest request)
        {
            var command = _mapper.Map<CreateAddressCommand>(request);
            command.StudentId = studentId;
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
            {
                return StatusCode(StatusCodes.Status201Created);
            }

            return ProblemDetails(result.Errors);
        }

        [HttpGet]
        [Route("{studentId}/address/{addressId}")]
        public async Task<IActionResult> GetStudentAddress(int studentId, int addressId)
        {
            var query = new GetStudentAddressByIdQuery(studentId, addressId);
            var result = await _mediator.Send(query);
            if (result.IsSuccess)
            {
                var response = _mapper.Map<StudentAddressResponse>(result.Value);
                return Ok(response);
            }

            return ProblemDetails(result.Errors);
        }

        [HttpDelete]
        [Route("{studentId}/address/{addressId}")]
        public async Task<IActionResult> DeleteStudentAddress(int studentId, int addressId)
        {
            var command = new DeleteAddressCommand(studentId, addressId);
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
            {
                return NoContent();
            }

            return ProblemDetails(result.Errors);
        }


    }
}
