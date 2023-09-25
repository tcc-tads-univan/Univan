using FluentResults;
using MediatR;
using Univan.Application.Validation;

namespace Univan.Application.Services.Subscriber.Command.InviteSubscription
{
    public class InviteSubscriptionCommandHandler : IRequestHandler<InviteSubscriptionCommand, Result>
    {
        public async Task<Result> Handle(InviteSubscriptionCommand request, CancellationToken cancellationToken)
        {
            Object student = null;
            //var student = _studentRepository.GetById(request.StudentId);
            
            if(student is null)
            {
                return Result.Fail(ValidationErrors.Student.NotFound);
            }

            Object driver = null;
            //var driver = _driverRepository.GetById(request.DriverId);

            if(driver is null)
            {
                return Result.Fail(ValidationErrors.Driver.NotFound);
            }

            //var subscription = new Subscription();

            //await _subscriptionRepository.CreateSubscription();

            return Result.Ok();
        }
    }
}
