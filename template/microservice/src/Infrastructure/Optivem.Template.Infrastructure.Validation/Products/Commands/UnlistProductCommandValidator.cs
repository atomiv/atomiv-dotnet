using FluentValidation;
using Optivem.Atomiv.Infrastructure.FluentValidation;
using Optivem.Template.Core.Application.Products.Commands;
using Optivem.Template.Core.Application.Products.Repositories;

namespace Optivem.Template.Infrastructure.Validation.Products.Commands
{
    public class UnlistProductCommandValidator : BaseValidator<UnlistProductCommand>
    {
        public UnlistProductCommandValidator(IProductReadRepository productReadRepository)
        {
            RuleFor(e => e.Id)
                .NotEmpty()
                .MustAsync((command, context, cancellation)
                    => productReadRepository.ExistsAsync(command.Id))
                .WithErrorCode(ValidationErrorCodes.NotFound);
        }
    }
}
