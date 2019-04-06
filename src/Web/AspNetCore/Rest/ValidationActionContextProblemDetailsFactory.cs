using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Optivem.Platform.Web.AspNetCore.Rest
{
    public class ValidationActionContextProblemDetailsFactory : IActionContextProblemDetailsFactory<ValidationProblemDetails>
    {
        private const string Title = "Validation Error";
        private const int StatusCode = (int)HttpStatusCode.UnprocessableEntity;

        public ValidationProblemDetails Create(ActionContext actionContext)
        {
            var validationErrors = GetValidationErrors(actionContext.ModelState);

            var problemDetails = new ValidationProblemDetails
            {
                Status = StatusCode,
                Title = Title,
                Detail = "Validation errors had occurred, see validationErrors for more details",
                ValidationErrors = validationErrors,
                Instance = null, // TODO: VC: Consolidate with the other factory
            };

            return problemDetails;
        }

        private static List<ValidationError> GetValidationErrors(ModelStateDictionary modelState)
        {
            var modelStates = modelState.Where(e => e.Value.Errors.Any()).ToList();
            var validationErrors = new List<ValidationError>();
            modelStates.ForEach(e => Append(validationErrors, e));
            return validationErrors;
        }

        private static void Append(List<ValidationError> validationErrors, KeyValuePair<string, ModelStateEntry> entry)
        {
            var name = entry.Key;
            var errors = entry.Value.Errors;

            foreach (var error in errors)
            {
                var validationError = new ValidationError
                {
                    Name = name,
                    Description = error.ErrorMessage,
                };

                validationErrors.Add(validationError);
            }
        }
    }
}
