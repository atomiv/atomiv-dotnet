using FluentValidation;
using Optivem.Infrastructure.FluentValidation;
using Optivem.Template.Core.Application.Customers;

namespace Optivem.Template.Infrastructure.FluentValidation.Customers
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
