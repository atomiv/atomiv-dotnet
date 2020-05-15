using FluentValidation;
using Optivem.Atomiv.Infrastructure.FluentValidation;
using Optivem.Atomiv.Template.Core.Application.Commands.Customers;
using Optivem.Atomiv.Template.Core.Domain.Customers;

namespace Optivem.Atomiv.Template.Infrastructure.Commands.Validation.Customers
{
    public class EditCustomerCommandValidator : BaseValidator<EditCustomerCommand>
    {
        public EditCustomerCommandValidator(ICustomerReadonlyRepository customerReadonlyRepository)
        {
            RuleFor(e => e.Id)
                .NotEmpty()
                .MustAsync((command, context, cancellation) 
                    => customerReadonlyRepository.ExistsAsync(command.Id))
                .WithErrorCode(ValidationErrorCodes.NotFound);

            RuleFor(e => e.FirstName)
                .NotNull();

            RuleFor(e => e.LastName)
                .NotNull();
        }
    }
}