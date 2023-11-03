using FluentResults;
using Univan.Domain.Enums;

namespace Univan.Domain.Errors
{
    public static partial class DomainError
    {
        public static class User
        {
            public static Error Duplicated => new Error("User already exist").WithMetadata(nameof(ErrorType), ErrorType.Conflit);
        }
    }
}
