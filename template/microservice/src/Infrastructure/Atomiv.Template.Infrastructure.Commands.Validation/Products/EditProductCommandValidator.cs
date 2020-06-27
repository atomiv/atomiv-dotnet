using FluentValidation;
using Atomiv.Infrastructure.FluentValidation;
using Atomiv.Template.Core.Application.Commands.Products;

namespace Atomiv.Template.Infrastructure.Commands.Validation.Products
{
    public class EditProductCommandValidator : BaseValidator<EditProductCommand>
    {
        public EditProductCommandValidator()
        {
            RuleFor(e => e.Id)
                .NotEmpty()
                .WithErrorCode(ValidationErrorCodes.NotFound);

            RuleFor(e => e.Description).NotNull();
            RuleFor(e => e.UnitPrice).GreaterThan(0);
        }
    }
}