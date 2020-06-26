using FluentValidation;
using Atomiv.Infrastructure.FluentValidation;
using Atomiv.Template.Core.Application.Commands.Orders;
using Atomiv.Template.Core.Domain.Orders;
using Atomiv.Template.Core.Domain.Products;

namespace Atomiv.Template.Infrastructure.Commands.Validation.Orders
{
    public class EditOrderCommandValidator : BaseValidator<EditOrderCommand>
    {
        public EditOrderCommandValidator()
        {
            RuleFor(e => e.Id)
                .NotEmpty()
                .WithErrorCode(ValidationErrorCodes.NotFound);

            RuleFor(e => e.OrderItems).NotNull();

            RuleForEach(e => e.OrderItems)
                .SetValidator(new EditOrderItemCommandValidator());
        }
    }

    public class EditOrderItemCommandValidator : BaseValidator<EditOrderItemCommand>
    {
        public EditOrderItemCommandValidator()
        {
            RuleFor(e => e.ProductId)
                .NotEmpty();
        }
    }
}