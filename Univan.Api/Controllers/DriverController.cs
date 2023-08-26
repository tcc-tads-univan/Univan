using Microsoft.AspNetCore.Mvc;
using Univan.Api.Contracts.Driver;

namespace Univan.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DriverController : ControllerBase
    {
        public DriverController()
        {

        }

        [HttpGet]
        [Route("{driverId}")]
        public async Task<IActionResult> GetDriverById(int driverId)
        {
            await Task.CompletedTask;
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDriver(CreateDriverRequest createDriverRequest)
        {
            await Task.CompletedTask;
            return Ok();
        }
    }
}
