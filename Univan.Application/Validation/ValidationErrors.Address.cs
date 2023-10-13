using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Univan.Domain.Enums;

namespace Univan.Application.Validation
{
    internal static partial class ValidationErrors
    {
        internal static class Address
        {
            static internal Error NotFound => new Error("The address was not found.").WithMetadata(nameof(ErrorType), ErrorType.NotFound);
        }
    }
}
