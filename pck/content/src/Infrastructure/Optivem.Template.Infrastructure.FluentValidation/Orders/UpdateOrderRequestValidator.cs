using FluentValidation;
using Optivem.Framework.Infrastructure.FluentValidation;
using Optivem.Template.Core.Application.Orders.Requests;

namespace Optivem.Template.Infrastructure.FluentValidation.Orders
{
    public class UpdateOrderRequestValidator : BaseValidator<UpdateOrderRequest>
    {
        public UpdateOrderRequestValidator()
        {
            RuleFor(e => e.OrderDetails).NotNull();
        }
    }
}