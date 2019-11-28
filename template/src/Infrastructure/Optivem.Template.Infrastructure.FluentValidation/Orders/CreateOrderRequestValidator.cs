using FluentValidation;
using Optivem.Framework.Infrastructure.FluentValidation;
using Optivem.Template.Core.Application.Orders.Requests;

namespace Optivem.Template.Infrastructure.FluentValidation.Orders
{
    public class CreateOrderRequestValidator : BaseValidator<CreateOrderRequest>
    {
        public CreateOrderRequestValidator()
        {
            RuleFor(e => e.CustomerId).NotEmpty();
            RuleFor(e => e.OrderItems).NotNull();
        }
    }
}