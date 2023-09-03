using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace Univan.Api.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ErrorHandlingMiddleware> _logger;
        public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger)
        {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);

                string response;

                if(exception is ValidationException ve)
                {
                    response = HandleValidationExeceptions(context, ve.Errors);
                }
                else
                {
                    response = HandleServerExeceptions(context);
                }

                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(response);
            }
        }

        private string HandleValidationExeceptions(HttpContext context, IEnumerable<ValidationFailure> validationErrors)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            
            string[] validationMessages = validationErrors.Select(s => s.ErrorMessage).ToArray();
            Dictionary<string, string[]> Errors = new Dictionary<string, string[]>
            {
                {"Fields", validationMessages }
            };

            ValidationProblemDetails validationProblemDetails = new ValidationProblemDetails(Errors)
            {
                Status = (int)HttpStatusCode.BadRequest,
            };

            return JsonSerializer.Serialize(validationProblemDetails);
        } 
        
        private string HandleServerExeceptions(HttpContext context)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            ProblemDetails problemDetails = new ProblemDetails()
            {
                Type = "Server Error",
                Title = "Server Error",
                Detail = "An internal server has occurred",
                Status = (int)HttpStatusCode.InternalServerError,
            };

            return JsonSerializer.Serialize(problemDetails);
        }
    }
}
