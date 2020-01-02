using FluentValidation;
using Optivem.Framework.Infrastructure.FluentValidation;
using Optivem.Template.Core.Application.Products.Commands;

namespace Optivem.Template.Infrastructure.Validation.Products
{
    public class UpdateProductRequestValidator : BaseValidator<UpdateProductCommand>
    {
        public UpdateProductRequestValidator()
        {
            RuleFor(e => e.Description).NotNull();
            RuleFor(e => e.UnitPrice).GreaterThan(0);
        }
    }
}