using FluentValidation;
using Atomiv.Infrastructure.FluentValidation;
using Generator.Core.Application.Customers.Requests;

namespace Generator.Infrastructure.FluentValidation.Customers
{
    public class UpdateCustomerRequestValidator : BaseValidator<UpdateCustomerRequest>
    {
        public UpdateCustomerRequestValidator()
        {
            RuleFor(e => e.FirstName).NotNull();
            RuleFor(e => e.LastName).NotNull();
        }
    }
}
