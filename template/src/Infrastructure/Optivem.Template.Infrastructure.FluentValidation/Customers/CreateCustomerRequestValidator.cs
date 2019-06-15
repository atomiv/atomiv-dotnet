using FluentValidation;
using Optivem.Template.Core.Application.Customers.Requests;

namespace Optivem.Template.Infrastructure.FluentValidation.Customers
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
