using FluentValidation;
using Atomiv.Infrastructure.FluentValidation;
using Atomiv.Template.Core.Application.Commands.Orders;

namespace Atomiv.Template.Infrastructure.Commands.Validation.Orders
{
    public class CancelOrderCommandValidator : BaseValidator<CancelOrderCommand>
    {
        public CancelOrderCommandValidator()
        {
            RuleFor(e => e.Id)
                .NotEmpty()
                .WithErrorCode(ValidationErrorCodes.NotFound);
        }
    }
}
