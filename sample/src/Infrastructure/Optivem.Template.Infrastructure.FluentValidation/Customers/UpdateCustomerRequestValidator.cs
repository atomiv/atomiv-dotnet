using FluentValidation;
using Optivem.NorthwindLite.Core.Application.Customers.Requests;

namespace Optivem.NorthwindLite.Infrastructure.FluentValidation.Customers
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
