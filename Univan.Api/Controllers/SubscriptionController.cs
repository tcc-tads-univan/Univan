using Microsoft.AspNetCore.Mvc;
using Univan.Api.Contracts.Subscription;

namespace Univan.Api.Controllers
{
    [Route("api")]
    public class SubscriptionController : BaseController
    {
        public SubscriptionController()
        {

        }

        [HttpPost]
        [Route("Driver/invite-student")]
        public async Task<IActionResult> InviteStudent(CreateInviteSubscriptionRequest request)
        {
            await Task.CompletedTask;
            return Ok();
        }

    }
}
