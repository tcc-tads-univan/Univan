using FluentResults;
using Univan.Domain.Enums;

namespace Univan.Application.Validation
{
    internal static partial class ValidationErrors
    {
        internal static class Student
        {
            internal static Error NotFound => new Error("The student was not found.").WithMetadata(nameof(ErrorType), ErrorType.NotFound);
            static internal Error AddressDeleteConflit => new Error("The address couldn't be deleted. The student already has a subscription.").WithMetadata(nameof(ErrorType), ErrorType.Conflit);
            static internal Error AlreadyHasSubscription => new Error("The student already has a subscription.").WithMetadata(nameof(ErrorType), ErrorType.Conflit);
        }
    }
}
