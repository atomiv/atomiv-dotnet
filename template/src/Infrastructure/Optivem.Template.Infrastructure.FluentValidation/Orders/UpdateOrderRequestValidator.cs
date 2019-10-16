using FluentValidation;
using Optivem.Framework.Infrastructure.FluentValidation;
using Optivem.Template.Core.Application.Orders.Requests;

namespace Optivem.Template.Infrastructure.FluentValidation.Orders
{
    public class UpdateOrderRequestValidator : BaseValidator<UpdateOrderRequest>
    {
        public UpdateOrderRequestValidator()
        {
            RuleFor(e => e.CustomerId).GreaterThan(0);
            RuleFor(e => e.OrderDetails).NotNull();
        }
    }
}