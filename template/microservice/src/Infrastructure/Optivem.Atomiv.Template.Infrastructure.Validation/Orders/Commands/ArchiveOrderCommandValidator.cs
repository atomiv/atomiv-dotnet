using FluentValidation;
using Optivem.Atomiv.Infrastructure.FluentValidation;
using Optivem.Atomiv.Template.Core.Application.Orders.Commands;
using Optivem.Atomiv.Template.Core.Application.Orders.Repositories;

namespace Optivem.Atomiv.Template.Infrastructure.Validation.Orders.Commands
{
    public class ArchiveOrderCommandValidator : BaseValidator<ArchiveOrderCommand>
    {
        public ArchiveOrderCommandValidator(IOrderQueryRepository orderReadRepository)
        {
            RuleFor(e => e.Id)
                .NotEmpty()
                .MustAsync((command, context, cancellation)
                    => orderReadRepository.ExistsAsync(command.Id))
                .WithErrorCode(ValidationErrorCodes.NotFound);
        }
    }
}
