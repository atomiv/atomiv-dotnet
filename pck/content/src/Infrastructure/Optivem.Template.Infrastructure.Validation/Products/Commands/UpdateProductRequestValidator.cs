using FluentValidation;
using Optivem.Atomiv.Infrastructure.FluentValidation;
using Optivem.Template.Core.Application.Products.Commands;
using Optivem.Template.Core.Application.Products.Repositories;

namespace Optivem.Template.Infrastructure.Validation.Products
{
    public class UpdateProductRequestValidator : BaseValidator<UpdateProductCommand>
    {
        public UpdateProductRequestValidator(IProductReadRepository productReadRepository)
        {
            RuleFor(e => e.Id)
                .NotEmpty()
                .MustAsync((command, context, cancellation)
                    => productReadRepository.ExistsAsync(command.Id))
                .WithErrorCode(ValidationErrorCodes.NotFound);

            RuleFor(e => e.Description).NotNull();
            RuleFor(e => e.UnitPrice).GreaterThan(0);
        }
    }
}