using FluentValidation;
using Optivem.Atomiv.Infrastructure.FluentValidation;
using Optivem.Atomiv.Template.Core.Application.Commands.Products;

namespace Optivem.Atomiv.Template.Infrastructure.Commands.Validation.Products
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