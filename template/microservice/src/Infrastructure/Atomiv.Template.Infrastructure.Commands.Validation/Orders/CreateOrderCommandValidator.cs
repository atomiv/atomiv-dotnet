using FluentValidation;
using Atomiv.Infrastructure.FluentValidation;
using Atomiv.Template.Core.Application.Commands.Orders;
using Atomiv.Template.Core.Domain.Customers;
using Atomiv.Template.Core.Domain.Products;

namespace Atomiv.Template.Infrastructure.Commands.Validation.Orders
{
    public class CreateOrderCommandValidator : BaseValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(e => e.CustomerId)
                .NotEmpty();

            RuleFor(e => e.CustomerId).NotEmpty();
            RuleFor(e => e.OrderItems).NotNull();

            RuleForEach(e => e.OrderItems)
                .SetValidator(new CreateOrderItemCommandValidator());
        }
    }

    public class CreateOrderItemCommandValidator : BaseValidator<CreateOrderItemCommand>
    {
        public CreateOrderItemCommandValidator()
        {
            RuleFor(e => e.ProductId)
                .NotEmpty();
        }
    }
}