using FluentValidation;
using Optivem.NorthwindLite.Core.Application.Customers.Requests;

namespace Optivem.NorthwindLite.Infrastructure.FluentValidation.Customers
{
    public class CreateCustomerRequestValidator : AbstractValidator<CreateCustomerRequest>
    {
        public CreateCustomerRequestValidator()
        {
            RuleFor(e => e.FirstName).NotNull();
            RuleFor(e => e.LastName).NotNull();
        }
    }
}
