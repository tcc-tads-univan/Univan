using FluentResults;
using Univan.Domain.Enums;

namespace Univan.Application.Validation
{
    internal static partial class ValidationErrors
    {
        internal static class Student
        {
            internal static Error NotFound => new Error("The student was not found.").WithMetadata(nameof(ErrorType), ErrorType.NotFound);
        }
    }
}
