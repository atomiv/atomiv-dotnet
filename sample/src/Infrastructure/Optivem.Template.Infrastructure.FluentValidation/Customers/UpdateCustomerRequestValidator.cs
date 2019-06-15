using FluentValidation;
using Optivem.Template.Core.Application.Customers.Requests;

namespace Optivem.Template.Infrastructure.FluentValidation.Customers
{
    public class UpdateCustomerRequestValidator : AbstractValidator<UpdateCustomerRequest>
    {
        public UpdateCustomerRequestValidator()
        {
            RuleFor(e => e.FirstName).NotNull();
            RuleFor(e => e.LastName).NotNull();
        }
    }
}
