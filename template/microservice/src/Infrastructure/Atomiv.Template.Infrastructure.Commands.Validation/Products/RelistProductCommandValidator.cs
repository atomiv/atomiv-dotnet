using FluentValidation;
using Atomiv.Infrastructure.FluentValidation;
using Atomiv.Template.Core.Application.Commands.Products;
using Atomiv.Template.Core.Domain.Products;

namespace Atomiv.Template.Infrastructure.Commands.Validation.Products
{
    public class RelistProductCommandValidator : BaseValidator<RelistProductCommand>
    {
        public RelistProductCommandValidator(IProductReadonlyRepository productReadonlyRepository)
        {
            RuleFor(e => e.Id)
                .NotEmpty()
                .MustAsync((command, context, cancellation)
                    => productReadonlyRepository.ExistsAsync(command.Id))
                .WithErrorCode(ValidationErrorCodes.NotFound);
        }
    }
}
