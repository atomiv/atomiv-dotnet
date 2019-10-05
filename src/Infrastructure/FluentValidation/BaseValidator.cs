using FluentValidation;
using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Common;
using System.Threading.Tasks;

namespace Optivem.Framework.Infrastructure.FluentValidation
{
    public abstract class BaseValidator<TRequest> : AbstractValidator<TRequest>, IRequestValidator<TRequest>
        where TRequest : IRequest
    {
        public async Task<IRequestValidationResult> ValidateAsync(TRequest request)
        {
            var result = await base.ValidateAsync(request);
            return new FluentValidationResult(result);
        }
    }
}
