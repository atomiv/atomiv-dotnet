using FluentValidation;
using Atomiv.Infrastructure.FluentValidation;
using Atomiv.Template.Core.Application.Commands.Orders;
using Atomiv.Template.Core.Domain.Orders;
using Atomiv.Template.Core.Domain.Products;

namespace Atomiv.Template.Infrastructure.Commands.Validation.Orders
{
    public class EditOrderRequestValidator : BaseValidator<EditOrderCommand>
    {
        public EditOrderRequestValidator(IOrderReadonlyRepository orderReadonlyRepository, IProductReadonlyRepository productReadonlyRepository)
        {
            RuleFor(e => e.Id)
                .NotEmpty()
                .MustAsync((command, context, cancellation)
                    => orderReadonlyRepository.ExistsAsync(command.Id))
                .WithErrorCode(ValidationErrorCodes.NotFound);

            RuleFor(e => e.OrderItems).NotNull();

            RuleForEach(e => e.OrderItems)
                .SetValidator(new UpdateOrderItemCommandValidator(productReadonlyRepository));
        }
    }

    public class UpdateOrderItemCommandValidator : BaseValidator<UpdateOrderItemCommand>
    {
        public UpdateOrderItemCommandValidator(IProductReadonlyRepository productReadonlyRepository)
        {
            RuleFor(e => e.ProductId)
                .MustAsync((command, context, cancellation)
                    => productReadonlyRepository.ExistsAsync(command.ProductId));
        }
    }
}