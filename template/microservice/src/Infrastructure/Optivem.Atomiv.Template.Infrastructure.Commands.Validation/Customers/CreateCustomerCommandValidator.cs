using FluentValidation;
using Optivem.Atomiv.Infrastructure.FluentValidation;
using Optivem.Atomiv.Template.Core.Application.Customers.Commands;

namespace Optivem.Atomiv.Template.Infrastructure.Commands.Validation.Customers
{
    public class CreateCustomerCommandValidator : BaseValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(e => e.FirstName).NotNull();
            RuleFor(e => e.LastName).NotNull();
        }
    }
}