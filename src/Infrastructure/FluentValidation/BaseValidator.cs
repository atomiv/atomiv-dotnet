using FluentValidation;
using Optivem.Framework.Core.Application;
using System.Threading.Tasks;

namespace Optivem.Framework.Infrastructure.FluentValidation
{
    public abstract class BaseValidator<TRequest> : AbstractValidator<TRequest>, IRequestValidator<TRequest>
    {
        public async Task<IRequestValidationResult> ValidateAsync(TRequest request)
        {
            var result = await base.ValidateAsync(request);
            return new FluentValidationResult(result);
        }
    }
}