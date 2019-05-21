using FluentValidation;
using Optivem.Core.Application;
using System.Threading.Tasks;

namespace Optivem.Infrastructure.Validation.FluentValidation
{
    public class FluentValidationRequestValidator<TRequest> : IRequestValidator<TRequest>
        where TRequest : IRequest
    {
        private IValidator<TRequest> _validator;

        public FluentValidationRequestValidator(IValidator<TRequest> validator)
        {
            _validator = validator;
        }

        public async Task<IValidationResult> ValidateAsync(TRequest request)
        {
            var result = await _validator.ValidateAsync(request);
            return new FluentValidationResult(result);
        }
    }
}