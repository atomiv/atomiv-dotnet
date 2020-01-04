using System.Linq;
using System.Threading.Tasks;

namespace Optivem.Framework.Core.Application
{
    public class RequestValidationHandler<TRequest> : IRequestValidationHandler<TRequest>
    {
        private IRequestValidator<TRequest> _validator;

        public RequestValidationHandler(IRequestValidator<TRequest> validator)
        {
            _validator = validator;
        }

        public async Task HandleAsync(TRequest request)
        {
            var result = await _validator.ValidateAsync(request);

            // TODO: VC: Map here custom status code to http status code
            // or return ValidationException and inside can see codes?


            if (!result.IsValid)
            {
                var hasNotFound = result.Errors.Any(e => e.ErrorCode == ValidationErrorCodes.NotFound);

                if(hasNotFound)
                {
                    throw new ExistenceException();
                }

                throw new ValidationException(result);
            }
        }
    }
}