using FluentValidation;
using Optivem.Atomiv.Infrastructure.FluentValidation;
using Optivem.Template.Core.Application.Customers.Queries;
using Optivem.Template.Core.Application.Customers.Repositories;

namespace Optivem.Template.Infrastructure.Validation.Customers.Queries
{
    public class FindCustomerQueryValidator : BaseValidator<FindCustomerQuery>
    {
        public FindCustomerQueryValidator(ICustomerReadRepository customerReadRepository)
        {
            RuleFor(e => e.Id)
                .NotEmpty()
                .MustAsync((query, context, cancellation)
                    => customerReadRepository.ExistsAsync(query.Id))
                .WithErrorCode(ValidationErrorCodes.NotFound);
        }
    }
}
