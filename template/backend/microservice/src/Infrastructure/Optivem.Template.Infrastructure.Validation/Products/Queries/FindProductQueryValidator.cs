using FluentValidation;
using Optivem.Framework.Infrastructure.FluentValidation;
using Optivem.Template.Core.Application.Products.Queries;
using Optivem.Template.Core.Application.Products.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Infrastructure.Validation.Products.Queries
{
    public class FindProductQueryValidator : BaseValidator<FindProductQuery>
    {
        public FindProductQueryValidator(IProductReadRepository productReadRepository)
        {
            RuleFor(e => e.Id)
                .NotEmpty()
                .MustAsync((query, context, cancellation)
                    => productReadRepository.ExistsAsync(query.Id))
                .WithErrorCode(ValidationErrorCodes.NotFound);
        }
    }
}
