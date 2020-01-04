using FluentValidation;
using Optivem.Framework.Infrastructure.FluentValidation;
using Optivem.Template.Core.Application.Customers.Queries;
using Optivem.Template.Core.Application.Customers.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Infrastructure.Validation.Customers.Queries
{
    public class FindCustomerQueryValidator : BaseValidator<FindCustomerQuery>
    {
        public FindCustomerQueryValidator(ICustomerReadRepository customerReadRepository)
        {
            RuleFor(e => e.Id)
                .NotEmpty()
                .MustAsync((query, context, cancellation)
                    => customerReadRepository.ExistsAsync(query.Id))
                .WithErrorCode(ValidationErrorCodes.NotFound);
        }
    }
}
