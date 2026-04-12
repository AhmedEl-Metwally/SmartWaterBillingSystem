using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SmartWaterBillingSystem.Application.Common.Models;

namespace SmartWaterBillingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected ActionResult HandleResult<T>(Result<T> result)
        {
            if (result.IsSuccess)
                return Ok(result);
            return HandleProblem(result.Errors);
        }

        private ActionResult HandleProblem(List<ErrorDetails> errors)
        {
            if (errors.Count == 0)
                return Problem(statusCode: 500, title: "An unexpected error occurred.");

            if (errors.All(E => E.Type == ErrorType.ValidationError))
            {
                var problemDetails = new ModelStateDictionary();
                foreach (var error in errors)
                {
                    ModelState.AddModelError(error.Code, error.Message);
                    return ValidationProblem(ModelState);
                }
            }

            var firstError = errors[0];
            return Problem(
                              title: firstError.Code,
                              detail: firstError.Message,
                              statusCode: MapErrorTypeToStatusCode(firstError.Type)
                          );
        }

        private static int MapErrorTypeToStatusCode(ErrorType type) => type switch
        {
            ErrorType.Failure => StatusCodes.Status500InternalServerError,
            ErrorType.ValidationError => StatusCodes.Status400BadRequest,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            ErrorType.Unauthorized => StatusCodes.Status401Unauthorized,
            ErrorType.Forbidden => StatusCodes.Status403Forbidden,
            _ => StatusCodes.Status500InternalServerError
        };
    }
}
