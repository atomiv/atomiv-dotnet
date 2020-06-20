using FluentValidation;
using Atomiv.Infrastructure.FluentValidation;
using Atomiv.Template.Core.Application.Commands.Orders;
using Atomiv.Template.Core.Domain.Orders;

namespace Atomiv.Template.Infrastructure.Commands.Validation.Orders
{
    public class CancelOrderCommandValidator : BaseValidator<CancelOrderCommand>
    {
        public CancelOrderCommandValidator(IOrderReadonlyRepository orderReadonlyRepository)
        {
            RuleFor(e => e.Id)
                .NotEmpty()
                .MustAsync((command, context, cancellation)
                    => orderReadonlyRepository.ExistsAsync(command.Id))
                .WithErrorCode(ValidationErrorCodes.NotFound);
        }
    }
}
