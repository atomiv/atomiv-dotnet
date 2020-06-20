using FluentValidation;
using Atomiv.Infrastructure.FluentValidation;
using Atomiv.Template.Core.Application.Commands.Customers;
using Atomiv.Template.Core.Domain.Customers;

namespace Atomiv.Template.Infrastructure.Commands.Validation.Customers
{
    public class DeleteCustomerCommandValidator : BaseValidator<DeleteCustomerCommand>
    {
        public DeleteCustomerCommandValidator(ICustomerReadonlyRepository customerReadonlyRepository)
        {
            RuleFor(e => e.Id)
                .NotEmpty()
                .MustAsync((command, context, cancellation)
                    => customerReadonlyRepository.ExistsAsync(command.Id))
                .WithErrorCode(ValidationErrorCodes.NotFound);
        }
    }
}
