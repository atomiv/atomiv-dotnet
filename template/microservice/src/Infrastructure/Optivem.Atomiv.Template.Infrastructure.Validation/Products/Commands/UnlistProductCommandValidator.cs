using FluentValidation;
using Optivem.Atomiv.Infrastructure.FluentValidation;
using Optivem.Atomiv.Template.Core.Application.Products.Commands;
using Optivem.Atomiv.Template.Core.Application.Products.Repositories;

namespace Optivem.Atomiv.Template.Infrastructure.Validation.Products.Commands
{
    public class UnlistProductCommandValidator : BaseValidator<UnlistProductCommand>
    {
        public UnlistProductCommandValidator(IProductQueryRepository productReadRepository)
        {
            RuleFor(e => e.Id)
                .NotEmpty()
                .MustAsync((command, context, cancellation)
                    => productReadRepository.ExistsAsync(command.Id))
                .WithErrorCode(ValidationErrorCodes.NotFound);
        }
    }
}
