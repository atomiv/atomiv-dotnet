using FluentValidation;
using Atomiv.Infrastructure.FluentValidation;
using Atomiv.Template.Core.Application.Queries.Customers;
using Atomiv.Template.Core.Domain.Customers;

namespace Atomiv.Template.Infrastructure.Queries.Validation.Customers
{
    public class ViewCustomerQueryValidator : BaseValidator<ViewCustomerQuery>
    {
        public ViewCustomerQueryValidator(ICustomerReadonlyRepository customerReadonlyRepository)
        {
            RuleFor(e => e.Id)
                .NotEmpty()
                .MustAsync((query, context, cancellation)
                    => customerReadonlyRepository.ExistsAsync(query.Id))
                .WithErrorCode(ValidationErrorCodes.NotFound);
        }
    }
}
