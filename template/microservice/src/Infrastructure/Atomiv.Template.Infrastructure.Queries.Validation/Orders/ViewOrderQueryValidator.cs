using FluentValidation;
using Atomiv.Infrastructure.FluentValidation;
using Atomiv.Template.Core.Application.Queries.Orders;
using Atomiv.Template.Core.Domain.Orders;

namespace Atomiv.Template.Infrastructure.Queries.Validation.Orders
{
    public class ViewOrderQueryValidator : BaseValidator<ViewOrderQuery>
    {
        public ViewOrderQueryValidator(IOrderReadonlyRepository orderReadonlyRepository)
        {
            RuleFor(e => e.Id)
                .NotEmpty()
                .MustAsync((query, context, cancellation)
                    => orderReadonlyRepository.ExistsAsync(query.Id))
                .WithErrorCode(ValidationErrorCodes.NotFound);
        }
    }
}
