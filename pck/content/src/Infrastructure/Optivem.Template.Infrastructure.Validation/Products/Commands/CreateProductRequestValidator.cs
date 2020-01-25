using FluentValidation;
using Optivem.Framework.Infrastructure.FluentValidation;
using Optivem.Template.Core.Application.Products.Commands;

namespace Optivem.Template.Infrastructure.Validation.Products
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