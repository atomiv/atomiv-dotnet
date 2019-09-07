using FluentValidation;
using Optivem.Framework.Infrastructure.FluentValidation;
using Optivem.Generator.Core.Application.Customers.Requests;

namespace Optivem.Generator.Infrastructure.FluentValidation.Customers
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
