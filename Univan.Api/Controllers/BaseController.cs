using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Univan.Domain.Enums;

namespace Univan.Api.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IActionResult ProblemDetails(List<IError> validationErrors)
        {
            var error = validationErrors[0];

            error.Metadata.TryGetValue(nameof(ErrorType), out var errorType);

            var responseStatusCode = errorType switch
            {
                ErrorType.NotFound => (int)HttpStatusCode.NotFound,
                ErrorType.Conflit => (int)HttpStatusCode.Conflict,
                ErrorType.Validation => (int)HttpStatusCode.BadRequest,
                _ => (int)HttpStatusCode.InternalServerError
            };

            return Problem(statusCode: responseStatusCode, title: error.Message);
        }

    }
}
