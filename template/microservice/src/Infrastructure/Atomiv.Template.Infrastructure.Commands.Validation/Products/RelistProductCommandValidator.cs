using FluentValidation;
using Atomiv.Infrastructure.FluentValidation;
using Atomiv.Template.Core.Application.Commands.Products;

namespace Atomiv.Template.Infrastructure.Commands.Validation.Products
{
    public class RelistProductCommandValidator : BaseValidator<RelistProductCommand>
    {
        public RelistProductCommandValidator()
        {
            RuleFor(e => e.Id)
                .NotEmpty()
                .WithErrorCode(ValidationErrorCodes.NotFound);
        }
    }
}
