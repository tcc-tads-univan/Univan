using FluentValidation;

namespace Univan.Application.Services.Subscriber.Command.InviteSubscription
{
    public class InviteSubscriptionCommandValidator : AbstractValidator<InviteSubscriptionCommand>
    {
        public InviteSubscriptionCommandValidator()
        {
            RuleFor(s => s.DriverId)
                .GreaterThan(0)
                .NotEmpty();
            
            RuleFor(s => s.StudentId)
                .GreaterThan(0)
                .NotEmpty();

            RuleFor(s => s.ExpirationDay)
                .NotEmpty()
                .GreaterThan(0)
                .LessThanOrEqualTo(30);

            RuleFor(s => s.MonthlyFee)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
