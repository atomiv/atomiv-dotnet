using FluentValidation;
using Optivem.NorthwindLite.Core.Application.Interface.Customers.Commands;

namespace Optivem.NorthwindLite.Infrastructure.Validation
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
