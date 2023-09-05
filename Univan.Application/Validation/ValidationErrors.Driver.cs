using FluentResults;
using Univan.Domain.Enums;

namespace Univan.Application.Validation
{
    internal static partial class ValidationErrors
    {
        internal static class Driver
        {
            static internal Error DriverNotFound => new Error("The driver was not found.").WithMetadata(nameof(ErrorType), ErrorType.NotFound);
            static internal Error VehicleNotFound => new Error("The vehicle was not found.").WithMetadata(nameof(ErrorType), ErrorType.NotFound);
        }
    }
}
