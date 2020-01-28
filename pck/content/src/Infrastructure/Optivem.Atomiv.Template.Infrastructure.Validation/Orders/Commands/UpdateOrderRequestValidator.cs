using FluentValidation;
using Optivem.Atomiv.Infrastructure.FluentValidation;
using Optivem.Atomiv.Template.Core.Application.Orders.Commands;
using Optivem.Atomiv.Template.Core.Application.Orders.Repositories;
using Optivem.Atomiv.Template.Core.Application.Products.Repositories;

namespace Optivem.Atomiv.Template.Infrastructure.Validation.Orders
{
    public class UpdateOrderRequestValidator : BaseValidator<UpdateOrderCommand>
    {
        public UpdateOrderRequestValidator(IOrderReadRepository orderReadRepository, IProductReadRepository productReadRepository)
        {
            RuleFor(e => e.Id)
                .NotEmpty()
                .MustAsync((command, context, cancellation)
                    => orderReadRepository.ExistsAsync(command.Id))
                .WithErrorCode(ValidationErrorCodes.NotFound);

            RuleFor(e => e.OrderItems).NotNull();

            RuleForEach(e => e.OrderItems)
                .SetValidator(new UpdateOrderItemCommandValidator(productReadRepository));
        }
    }

    public class UpdateOrderItemCommandValidator : BaseValidator<UpdateOrderItemCommand>
    {
        public UpdateOrderItemCommandValidator(IProductReadRepository productReadRepository)
        {
            RuleFor(e => e.ProductId)
                .MustAsync((command, context, cancellation)
                    => productReadRepository.ExistsAsync(command.ProductId));
        }
    }
}