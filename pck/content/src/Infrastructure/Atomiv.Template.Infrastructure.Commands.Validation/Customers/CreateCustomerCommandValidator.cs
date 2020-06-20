using FluentValidation;
using Atomiv.Infrastructure.FluentValidation;
using Atomiv.Template.Core.Application.Commands.Customers;

namespace Atomiv.Template.Infrastructure.Commands.Validation.Customers
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