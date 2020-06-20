using FluentValidation;
using Atomiv.Infrastructure.FluentValidation;
using Atomiv.Template.Core.Application.Queries.Products;
using Atomiv.Template.Core.Domain.Products;

namespace Atomiv.Template.Infrastructure.Queries.Validation.Products
{
    public class ViewProductQueryValidator : BaseValidator<ViewProductQuery>
    {
        public ViewProductQueryValidator(IProductReadonlyRepository productReadonlyRepository)
        {
            RuleFor(e => e.Id)
                .NotEmpty()
                .MustAsync((query, context, cancellation)
                    => productReadonlyRepository.ExistsAsync(query.Id))
                .WithErrorCode(ValidationErrorCodes.NotFound);
        }
    }
}
