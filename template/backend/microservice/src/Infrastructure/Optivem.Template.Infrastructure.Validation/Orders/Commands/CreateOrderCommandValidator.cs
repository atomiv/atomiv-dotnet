using FluentValidation;
using Optivem.Framework.Infrastructure.FluentValidation;
using Optivem.Template.Core.Application.Orders.Commands;

namespace Optivem.Template.Infrastructure.Validation.Orders
{
    public class CreateOrderCommandValidator : BaseValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(e => e.CustomerId).NotEmpty();
            RuleFor(e => e.OrderItems).NotNull();
        }
    }
}