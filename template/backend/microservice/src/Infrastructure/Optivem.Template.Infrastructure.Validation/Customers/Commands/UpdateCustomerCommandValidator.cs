using FluentValidation;
using Optivem.Framework.Core.Application.Validators;
using Optivem.Framework.Infrastructure.FluentValidation;
using Optivem.Template.Core.Application.Customers.Commands;
using Optivem.Template.Core.Application.Customers.Repositories;

namespace Optivem.Template.Infrastructure.Validation.Customers
{
    public class UpdateCustomerCommandValidator : BaseValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator(ICustomerReadRepository customerReadRepository)
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