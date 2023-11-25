using FluentValidation;

namespace Univan.Application.Services.Subscriber.Command.UpdatePayment
{
    public class UpdatePaymentCommandValidator : AbstractValidator<UpdatePaymentCommand>
    {
        public UpdatePaymentCommandValidator()
        {
            RuleFor(s => s.DriverId)
                .GreaterThan(0)
                .NotEmpty();
            
            RuleFor(s => s.SubscriptionId)
                .GreaterThan(0)
                .NotEmpty();
            
            RuleFor(s => s.PaymentId)
                .GreaterThan(0)
                .NotEmpty();
        }
    }
}
