using FluentValidation;

namespace Univan.Application.Services.Subscriber.Command.CancelSubscription
{
    public class CancelSubscriptionCommandValidator : AbstractValidator<CancelSubscriptionCommand>
    {
        public CancelSubscriptionCommandValidator()
        {
            RuleFor(s => s.DriverId)
                .GreaterThan(0)
                .NotEmpty();

            RuleFor(s => s.SubscriptionId)
                .GreaterThan(0)
                .NotEmpty();
        }
    }
}
