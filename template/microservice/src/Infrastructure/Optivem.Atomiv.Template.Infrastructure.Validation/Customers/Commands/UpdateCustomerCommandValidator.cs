using FluentValidation;
using Optivem.Atomiv.Infrastructure.FluentValidation;
using Optivem.Atomiv.Template.Core.Application.Customers.Commands;
using Optivem.Atomiv.Template.Core.Application.Customers.Repositories;

namespace Optivem.Atomiv.Template.Infrastructure.Validation.Customers
{
    public class UpdateCustomerCommandValidator : BaseValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator(ICustomerQueryRepository customerReadRepository)
        {
            RuleFor(e => e.Id)
                .NotEmpty()
                .MustAsync((command, context, cancellation) 
                    => customerReadRepository.ExistsAsync(command.Id))
                .WithErrorCode(ValidationErrorCodes.NotFound);

            RuleFor(e => e.FirstName)
                .NotNull();

            RuleFor(e => e.LastName)
                .NotNull();
        }
    }
}