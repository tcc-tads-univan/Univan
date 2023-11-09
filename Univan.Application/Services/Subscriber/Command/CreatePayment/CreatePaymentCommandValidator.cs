using FluentValidation;

namespace Univan.Application.Services.Subscriber.Command.CreatePayment
{
    public class CreatePaymentCommandValidator : AbstractValidator<CreatePaymentCommand>
    {
        public CreatePaymentCommandValidator()
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
