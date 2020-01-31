using FluentValidation;
using Optivem.Atomiv.Infrastructure.FluentValidation;
using Optivem.Atomiv.Template.Core.Application.Products.Queries;
using Optivem.Atomiv.Template.Core.Application.Products.Repositories;

namespace Optivem.Atomiv.Template.Infrastructure.Validation.Products.Queries
{
    public class FindProductQueryValidator : BaseValidator<FindProductQuery>
    {
        public FindProductQueryValidator(IProductQueryRepository productReadRepository)
        {
            RuleFor(e => e.Id)
                .NotEmpty()
                .MustAsync((query, context, cancellation)
                    => productReadRepository.ExistsAsync(query.Id))
                .WithErrorCode(ValidationErrorCodes.NotFound);
        }
    }
}
