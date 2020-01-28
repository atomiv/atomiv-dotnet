using FluentValidation;
using Optivem.Atomiv.Core.Application;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Infrastructure.FluentValidation
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