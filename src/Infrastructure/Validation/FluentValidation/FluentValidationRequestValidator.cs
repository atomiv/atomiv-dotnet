using FluentValidation;
using Optivem.Core.Application;

namespace Optivem.Infrastructure.Validation.FluentValidation
{
    public class FluentValidationRequestValidator<TRequest> : IRequestValidator<TRequest>
    {
        private IValidator<TRequest> _validator;

        public FluentValidationRequestValidator(IValidator<TRequest> validator)
        {
            _validator = validator;
        }

        public IValidationResult Validate(TRequest request)
        {
            var result = _validator.Validate(request);
            return new FluentValidationResult(result);
        }
    }
}
