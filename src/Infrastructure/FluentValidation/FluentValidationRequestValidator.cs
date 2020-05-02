using FluentValidation;
using FluentValidation.Results;
using Optivem.Atomiv.Core.Application;
using System.Linq;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Infrastructure.FluentValidation
{
    public class FluentValidationRequestValidator<TRequest> : IRequestValidator<TRequest>
    {
        private IValidator<TRequest> _validator;

        public FluentValidationRequestValidator(IValidator<TRequest> validator)
        {
            _validator = validator;
        }

        public async Task<RequestValidationResult> ValidateAsync(TRequest request)
        {
            var result = await _validator.ValidateAsync(request);

            return result.ToRequestValidationResult();
        }
    }
}