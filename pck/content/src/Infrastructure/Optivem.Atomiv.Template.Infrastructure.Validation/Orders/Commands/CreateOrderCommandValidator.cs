using FluentValidation;
using Optivem.Atomiv.Infrastructure.FluentValidation;
using Optivem.Atomiv.Template.Core.Application.Customers.Repositories;
using Optivem.Atomiv.Template.Core.Application.Orders.Commands;
using Optivem.Atomiv.Template.Core.Application.Products.Repositories;

namespace Optivem.Atomiv.Template.Infrastructure.Validation.Orders
{
    public class CreateOrderCommandValidator : BaseValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator(ICustomerReadRepository customerReadRepository, IProductReadRepository productReadRepository)
        {
            RuleFor(e => e.CustomerId)
                .NotEmpty()
                .MustAsync((command, context, cancellation)
                    => customerReadRepository.ExistsAsync(command.CustomerId));

            RuleFor(e => e.CustomerId).NotEmpty();
            RuleFor(e => e.OrderItems).NotNull();

            RuleForEach(e => e.OrderItems)
                .SetValidator(new CreateOrderItemCommandValidator(productReadRepository));
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