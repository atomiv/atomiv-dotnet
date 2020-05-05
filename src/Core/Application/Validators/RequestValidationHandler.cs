using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Core.Application
{
    public class RequestValidationHandler<TRequest> : IRequestValidationHandler<TRequest>
    {
        private IEnumerable<IRequestValidator<TRequest>> _validators;

        public RequestValidationHandler(IEnumerable<IRequestValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task HandleAsync(TRequest request)
        {
            var isValid = true;
            var errors = new List<RequestValidationError>();

            foreach(var validator in _validators)
            {
                var result = await validator.ValidateAsync(request);

                // TODO: VC: Map here custom status code to http status code
                // or return ValidationException and inside can see codes?

                if (!result.IsValid)
                {
                    var hasNotFound = result.Errors
                        .Any(e => e.ErrorCode == ValidationErrorCodes.NotFound);

                    if (hasNotFound)
                    {
                        throw new ExistenceException();
                    }

                    isValid = false;
                    errors.AddRange(result.Errors);
                }
            }

            if (!isValid)
            {
                var result = new RequestValidationResult(isValid, errors);
                throw new ValidationException(result);
            }
        }
    }
}