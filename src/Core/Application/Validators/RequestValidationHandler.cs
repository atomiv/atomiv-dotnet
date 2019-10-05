using Optivem.Framework.Core.Common;
using System.Threading.Tasks;

namespace Optivem.Framework.Core.Application
{
    public class RequestValidationHandler<TRequest> : IRequestValidationHandler<TRequest>
        where TRequest : IRequest
    {
        private IRequestValidator<TRequest> _validator;

        public RequestValidationHandler(IRequestValidator<TRequest> validator)
        {
            _validator = validator;
        }

        public async Task HandleAsync(TRequest request)
        {
            var result = await _validator.ValidateAsync(request);

            if (!result.IsValid)
            {
                throw new InvalidRequestException(result);
            }
        }
    }
}