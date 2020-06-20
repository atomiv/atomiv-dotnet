using FluentValidation;
using Atomiv.Core.Application;
using System.Threading.Tasks;

namespace Atomiv.Infrastructure.FluentValidation
{
    public abstract class BaseValidator<TRequest> : AbstractValidator<TRequest>, IRequestValidator<TRequest>
    {
        public async Task<RequestValidationResult> ValidateAsync(TRequest request)
        {
            var result = await base.ValidateAsync(request);
            return result.ToRequestValidationResult();
        }
    }
}