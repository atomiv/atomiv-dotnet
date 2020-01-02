using FluentValidation;
using Optivem.Framework.Infrastructure.FluentValidation;
using Optivem.Template.Core.Application.Customers.Commands;

namespace Optivem.Template.Infrastructure.Validation.Customers
{
    public class CreateCustomerRequestValidator : BaseValidator<CreateCustomerCommand>
    {
        public CreateCustomerRequestValidator()
        {
            RuleFor(e => e.FirstName).NotNull();
            RuleFor(e => e.LastName).NotNull();
        }
    }
}