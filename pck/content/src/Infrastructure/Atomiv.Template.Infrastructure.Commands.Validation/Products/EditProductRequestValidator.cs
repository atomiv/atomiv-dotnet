using FluentValidation;
using Atomiv.Infrastructure.FluentValidation;
using Atomiv.Template.Core.Application.Commands.Products;
using Atomiv.Template.Core.Domain.Products;

namespace Atomiv.Template.Infrastructure.Commands.Validation.Products
{
    public class EditProductRequestValidator : BaseValidator<EditProductCommand>
    {
        public EditProductRequestValidator(IProductReadonlyRepository productReadonlyRepository)
        {
            RuleFor(e => e.Id)
                .NotEmpty()
                .MustAsync((command, context, cancellation)
                    => productReadonlyRepository.ExistsAsync(command.Id))
                .WithErrorCode(ValidationErrorCodes.NotFound);

            RuleFor(e => e.Description).NotNull();
            RuleFor(e => e.UnitPrice).GreaterThan(0);
        }
    }
}