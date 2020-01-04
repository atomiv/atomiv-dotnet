using FluentValidation;
using Optivem.Framework.Infrastructure.FluentValidation;
using Optivem.Template.Core.Application.Orders.Commands;
using Optivem.Template.Core.Application.Orders.Repositories;

namespace Optivem.Template.Infrastructure.Validation.Orders
{
    public class UpdateOrderRequestValidator : BaseValidator<UpdateOrderCommand>
    {
        public UpdateOrderRequestValidator(IOrderReadRepository orderReadRepository)
        {
            RuleFor(e => e.Id)
                .NotEmpty()
                .MustAsync((command, context, cancellation)
                    => orderReadRepository.ExistsAsync(command.Id))
                .WithErrorCode(ValidationErrorCodes.NotFound);

            RuleFor(e => e.OrderItems).NotNull();
        }
    }
}