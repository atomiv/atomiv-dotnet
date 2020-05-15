using FluentValidation;
using Optivem.Atomiv.Infrastructure.FluentValidation;
using Optivem.Atomiv.Template.Core.Application.Commands.Orders;
using Optivem.Atomiv.Template.Core.Domain.Customers;
using Optivem.Atomiv.Template.Core.Domain.Products;

namespace Optivem.Atomiv.Template.Infrastructure.Commands.Validation.Orders
{
    public class CreateOrderCommandValidator : BaseValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator(ICustomerReadonlyRepository customerReadonlyRepository, IProductReadonlyRepository productReadonlyRepository)
        {
            RuleFor(e => e.CustomerId)
                .NotEmpty()
                .MustAsync((command, context, cancellation)
                    => customerReadonlyRepository.ExistsAsync(command.CustomerId));

            RuleFor(e => e.CustomerId).NotEmpty();
            RuleFor(e => e.OrderItems).NotNull();

            RuleForEach(e => e.OrderItems)
                .SetValidator(new CreateOrderItemCommandValidator(productReadonlyRepository));
        }
    }

    public class CreateOrderItemCommandValidator : BaseValidator<CreateOrderItemCommand>
    {
        public CreateOrderItemCommandValidator(IProductReadonlyRepository productReadonlyRepository)
        {
            RuleFor(e => e.ProductId)
                .MustAsync((command, context, cancellation)
                    => productReadonlyRepository.ExistsAsync(command.ProductId));
        }
    }
}