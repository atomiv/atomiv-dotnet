using FluentValidation;
using Optivem.Atomiv.Infrastructure.FluentValidation;
using Optivem.Template.Core.Application.Orders.Queries;
using Optivem.Template.Core.Application.Orders.Repositories;

namespace Optivem.Template.Infrastructure.Validation.Orders.Queries
{
    public class FindOrderQueryValidator : BaseValidator<FindOrderQuery>
    {
        public FindOrderQueryValidator(IOrderReadRepository orderReadRepository)
        {
            RuleFor(e => e.Id)
                .NotEmpty()
                .MustAsync((query, context, cancellation)
                    => orderReadRepository.ExistsAsync(query.Id))
                .WithErrorCode(ValidationErrorCodes.NotFound);
        }
    }
}
