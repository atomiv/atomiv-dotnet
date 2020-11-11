using Atomiv.Core.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Atomiv.Core.Application
{
    public class RequestValidationResult
    {
        public RequestValidationResult(bool isValid, IEnumerable<RequestValidationError> errors)
        {
            IsValid = isValid;
            Errors = errors;
        }

        public bool IsValid { get; }

        public IEnumerable<RequestValidationError> Errors { get; }

        public static RequestValidationResult From(ValidationResult validationResult)
        {
            var isValid = validationResult.IsValid;

            var errors = validationResult
                .RuleResults
                .Select(e => RequestValidationError.From(e))
                .ToList();

            return new RequestValidationResult(isValid, errors);
        }
    }
}
