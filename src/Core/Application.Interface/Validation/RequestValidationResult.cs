using System.Collections.Generic;

namespace Optivem.Atomiv.Core.Application
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
    }
}
