using FluentResults;
using Univan.Domain.Enums;

namespace Univan.Domain.Errors
{
    public static partial class DomainError
    {
        public static class User
        {
            public static Error DuplicatedEmail => new Error("Email is already in use").WithMetadata(nameof(ErrorType), ErrorType.Conflit);
        }
    }
}
