using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Core.Application
{
    public class ValidationFilter<TRequest> : IValidationFilter<TRequest>
        where TRequest : IRequest
    {
        private IRequestValidator<TRequest> _validator;

        public ValidationFilter(IRequestValidator<TRequest> validator)
        {
            _validator = validator;
        }

        public async Task HandleAsync(TRequest request)
        {
            var result = await _validator.ValidateAsync(request);

            if(!result.IsValid)
            {
                throw new ValidationException(result);
            }
        }
    }
}
