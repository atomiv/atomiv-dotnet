using FluentValidation;
using Optivem.Infrastructure.FluentValidation;
using Optivem.Template.Core.Application.Customers;

namespace Optivem.Template.Infrastructure.FluentValidation.Customers
{
    public class CreateCustomerRequestValidator : FluentValidationAbstractValidator<CreateCustomerRequest>
    {
        public CreateCustomerRequestValidator()
        {
            RuleFor(e => e.FirstName).NotNull();
            RuleFor(e => e.LastName).NotNull();
        }
    }
}
