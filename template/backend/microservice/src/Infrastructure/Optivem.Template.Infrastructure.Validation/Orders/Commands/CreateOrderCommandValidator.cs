using FluentValidation;
using Optivem.Framework.Infrastructure.FluentValidation;
using Optivem.Template.Core.Application.Customers.Repositories;
using Optivem.Template.Core.Application.Orders.Commands;
using Optivem.Template.Core.Application.Products.Repositories;

namespace Optivem.Template.Infrastructure.Validation.Orders
{
    public class CreateOrderCommandValidator : BaseValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator(ICustomerReadRepository customerReadRepository)
        {
            RuleFor(e => e.CustomerId)
                .NotEmpty()
                .MustAsync((command, context, cancellation)
                    => customerReadRepository.ExistsAsync(command.CustomerId));

            RuleFor(e => e.CustomerId).NotEmpty();
            RuleFor(e => e.OrderItems).NotNull();
        }
    }

    public class CreateOrderItemCommandValidator : BaseValidator<CreateOrderItemCommand>
    {
        public CreateOrderItemCommandValidator(IProductReadRepository productReadRepository)
        {
            RuleFor(e => e.ProductId)
                .MustAsync((command, context, cancellation)
                    => productReadRepository.ExistsAsync(command.ProductId));
        }
    }
}