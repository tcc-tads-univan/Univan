using FluentResults;
using Univan.Domain.Enums;

namespace Univan.Application.Validation
{
    internal static partial class ValidationErrors
    {
        internal static class Subscription
        {
            internal static Error StudentSubscriptionNotFound => new Error("There is no subscription for this student.").WithMetadata(nameof(ErrorType), ErrorType.NotFound);
            internal static Error DriverSubscriptionNotFound => new Error("The driver was not found or does not have students subscriptions.").WithMetadata(nameof(ErrorType), ErrorType.NotFound);
            internal static Error NotFound => new Error("Subscription was not found.").WithMetadata(nameof(ErrorType), ErrorType.NotFound);
            internal static Error StudentsLimitation => new Error("You cannot invite more students.").WithMetadata(nameof(ErrorType), ErrorType.NotFound);
        }
    }
}
