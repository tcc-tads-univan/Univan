using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Univan.Api.Contracts.Subscription;
using Univan.Application.Services.Subscriber.Command.AcceptSubscription;
using Univan.Application.Services.Subscriber.Command.DeclineSubscription;
using Univan.Application.Services.Subscriber.Command.InviteSubscription;
using Univan.Application.Services.Subscriber.Queries.GetDriverSubscriptionById;
using Univan.Application.Services.Subscriber.Queries.GetDriverSubscriptions;
using Univan.Application.Services.Subscriber.Queries.GetStudentPendingSubscriptions;
using Univan.Application.Services.Subscriber.Queries.GetStudentSubscription;

namespace Univan.Api.Controllers
{
    [Route("api")]
    public class SubscriptionController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public SubscriptionController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("Driver/invite-student")]
        public async Task<IActionResult> InviteStudent(CreateInviteSubscriptionRequest request)
        {
            var command = _mapper.Map<InviteSubscriptionCommand>(request);
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
            {
                return Ok();
            }

            return ProblemDetails(result.Errors);
        }

        [HttpPost]
        [Route("Subscription/{subscriptionId}/decline")]
        public async Task<IActionResult> StudentDeclineSubscription(int subscriptionId)
        {
            var command = new DeclineSubscriptionCommand(subscriptionId);
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
            {
                return NoContent();
            }

            return ProblemDetails(result.Errors);
        }

        [HttpPost]
        [Route("Subscription/{subscriptionId}/accept")]
        public async Task<IActionResult> StudentAcceptSubscription(int subscriptionId)
        {
            var command = new AcceptSubscriptionCommand(subscriptionId);
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
            {
                return NoContent();
            }

            return ProblemDetails(result.Errors);
        }

        [HttpGet]
        [Route("Driver/{driverId}/subscriptions")]
        public async Task<IActionResult> GetDriverSubscriptions(int driverId)
        {
            var command = new GetDriverSubscriptionsQuery(driverId);
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
            {
                var subscriptions = _mapper.Map<DriverSubscriptionsResponse>(result.Value);
                return Ok(subscriptions);
            }

            return ProblemDetails(result.Errors);
        }

        [HttpGet]
        [Route("Driver/{driverId}/subscriptions/{subscriptionId}")]
        public async Task<IActionResult> GetDriverSubscriptionById(int driverId, int subscriptionId)
        {
            var command = new GetDriverSubscriptionByIdQuery(driverId, subscriptionId);
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
            {
                var subscription = _mapper.Map<DriverStudentSubscriptionResponse>(result.Value);
                return Ok(subscription);
            }

            return ProblemDetails(result.Errors);
        }

        [HttpGet]
        [Route("Student/{studentId}/pending-subscriptions")]
        public async Task<IActionResult> GetStudentPendingSubscriptions(int studentId)
        {
            var command = new GetStudentPendingSubscriptionsQuery(studentId);
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
            {
                var pendingSubscription = _mapper.Map<List<StudentPendingSubscriptionsResponse>>(result.Value);
                return Ok(pendingSubscription);
            }

            return ProblemDetails(result.Errors);
        } 
        
        [HttpGet]
        [Route("Student/{studentId}/subscription")]
        public async Task<IActionResult> GetStudentSubscription(int studentId)
        {
            var command = new GetStudentSubscriptionQuery(studentId);
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
            {
                var studentSubscription = _mapper.Map<StudentSubscriptionResponse>(result.Value);
                return Ok(studentSubscription);
            }

            return ProblemDetails(result.Errors);
        }

    }
}
