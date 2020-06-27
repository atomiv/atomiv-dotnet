using FluentValidation;
using Atomiv.Infrastructure.FluentValidation;
using Atomiv.Template.Core.Application.Queries.Orders;

namespace Atomiv.Template.Infrastructure.Queries.Validation.Orders
{
    public class ViewOrderQueryValidator : BaseValidator<ViewOrderQuery>
    {
        public ViewOrderQueryValidator()
        {
            RuleFor(e => e.Id)
                .NotEmpty()
                .WithErrorCode(ValidationErrorCodes.NotFound);
        }
    }
}
