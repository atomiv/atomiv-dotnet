using FluentValidation;
using Optivem.NorthwindLite.Core.Application.Interface.Requests.Customers;

namespace Optivem.NorthwindLite.Infrastructure.Validation
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
