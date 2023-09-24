using FluentResults;
using Univan.Domain.Enums;

namespace Univan.Application.Validation
{
    internal static partial class ValidationErrors
    {
        internal static class Subscription
        {
            internal static Error StudentSubscriptionNotFound => new Error("Student subscription was not found.").WithMetadata(nameof(ErrorType), ErrorType.NotFound);
            internal static Error DriverSubscriptionNotFound => new Error("Driver subscription was not found.").WithMetadata(nameof(ErrorType), ErrorType.NotFound);
        }
    }
}
