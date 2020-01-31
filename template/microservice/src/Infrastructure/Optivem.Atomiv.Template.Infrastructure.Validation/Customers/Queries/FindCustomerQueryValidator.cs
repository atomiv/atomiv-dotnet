using FluentValidation;
using Optivem.Atomiv.Infrastructure.FluentValidation;
using Optivem.Atomiv.Template.Core.Application.Customers.Queries;
using Optivem.Atomiv.Template.Core.Application.Customers.Repositories;

namespace Optivem.Atomiv.Template.Infrastructure.Validation.Customers.Queries
{
    public class FindCustomerQueryValidator : BaseValidator<FindCustomerQuery>
    {
        public FindCustomerQueryValidator(ICustomerQueryRepository customerReadRepository)
        {
            RuleFor(e => e.Id)
                .NotEmpty()
                .MustAsync((query, context, cancellation)
                    => customerReadRepository.ExistsAsync(query.Id))
                .WithErrorCode(ValidationErrorCodes.NotFound);
        }
    }
}
