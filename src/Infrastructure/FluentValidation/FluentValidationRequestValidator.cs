using FluentValidation;
using Optivem.Framework.Core.Application;
using System.Threading.Tasks;

namespace Optivem.Framework.Infrastructure.FluentValidation
{
    public class FluentValidationRequestValidator<TRequest> : IRequestValidator<TRequest>
    {
        private IValidator<TRequest> _validator;

        public FluentValidationRequestValidator(IValidator<TRequest> validator)
        {
            _validator = validator;
        }

        public async Task<IRequestValidationResult> ValidateAsync(TRequest request)
        {
            var result = await _validator.ValidateAsync(request);
            return new FluentValidationResult(result);
        }
    }
}