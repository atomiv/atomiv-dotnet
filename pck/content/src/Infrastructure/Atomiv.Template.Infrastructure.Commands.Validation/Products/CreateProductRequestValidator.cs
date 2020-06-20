using FluentValidation;
using Atomiv.Infrastructure.FluentValidation;
using Atomiv.Template.Core.Application.Commands.Products;

namespace Atomiv.Template.Infrastructure.Commands.Validation.Products
{
    public class CreateProductRequestValidator : BaseValidator<CreateProductCommand>
    {
        public CreateProductRequestValidator()
        {
            RuleFor(e => e.Code).NotNull();
            RuleFor(e => e.Description).NotNull();
            RuleFor(e => e.UnitPrice).GreaterThan(0);
        }
    }
}