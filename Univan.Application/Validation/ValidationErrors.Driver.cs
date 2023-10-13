using FluentResults;
using Univan.Domain.Enums;

namespace Univan.Application.Validation
{
    internal static partial class ValidationErrors
    {
        internal static class Driver
        {
            static internal Error NotFound => new Error("The driver was not found.").WithMetadata(nameof(ErrorType), ErrorType.NotFound);
            static internal Error VehicleNotFound => new Error("The driver doesn't have a vehicle.").WithMetadata(nameof(ErrorType), ErrorType.Validation);
            static internal Error VehicleDeleteConflit => new Error("The vehicle couldn't be deleted. The driver already has student subscriptions.").WithMetadata(nameof(ErrorType), ErrorType.Conflit);
        }
    }
}
