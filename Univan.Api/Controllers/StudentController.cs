using Microsoft.AspNetCore.Mvc;
using Univan.Api.Contracts.Student;

namespace Univan.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        public StudentController()
        {

        }

        [HttpGet]
        [Route("{studentId}")]
        public async Task<IActionResult> GetStudentById(int studentId)
        {
            await Task.CompletedTask;
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent(CreateStudentRequest createStudentRequest)
        {
            await Task.CompletedTask;
            return Ok();
        }
    }
}
