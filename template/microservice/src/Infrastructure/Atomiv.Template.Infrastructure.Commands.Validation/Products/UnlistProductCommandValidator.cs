using FluentValidation;
using Atomiv.Infrastructure.FluentValidation;
using Atomiv.Template.Core.Application.Commands.Products;

namespace Atomiv.Template.Infrastructure.Commands.Validation.Products
{
    public class UnlistProductCommandValidator : BaseValidator<UnlistProductCommand>
    {
        public UnlistProductCommandValidator()
        {
            RuleFor(e => e.Id)
                .NotEmpty()
                .WithErrorCode(ValidationErrorCodes.NotFound);
        }
    }
}
