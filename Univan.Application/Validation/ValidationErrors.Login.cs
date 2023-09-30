using FluentResults;
using Univan.Domain.Enums;

namespace Univan.Application.Validation
{
    internal static partial class ValidationErrors
    {
        internal static class Login
        {
            internal static Error InvalidCredentials => new Error("Email or password is invalid.").WithMetadata(nameof(ErrorType), ErrorType.Validation);
        }
    }
}
