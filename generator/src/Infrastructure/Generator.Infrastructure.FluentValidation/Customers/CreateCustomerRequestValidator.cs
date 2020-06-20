using FluentValidation;
using Atomiv.Infrastructure.FluentValidation;
using Generator.Core.Application.Customers.Requests;

namespace Generator.Infrastructure.FluentValidation.Customers
{
    public class CreateCustomerRequestValidator : BaseValidator<CreateCustomerRequest>
    {
        public CreateCustomerRequestValidator()
        {
            RuleFor(e => e.FirstName).NotNull();
            RuleFor(e => e.LastName).NotNull();
        }
    }
}
