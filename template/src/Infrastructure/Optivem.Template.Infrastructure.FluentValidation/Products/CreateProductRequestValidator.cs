using FluentValidation;
using Optivem.Framework.Infrastructure.FluentValidation;
using Optivem.Template.Core.Application.Products.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Infrastructure.FluentValidation.Products
{
    public class CreateProductRequestValidator : BaseValidator<CreateProductRequest>
    {
        public CreateProductRequestValidator()
        {
            RuleFor(e => e.Code).NotNull();
            RuleFor(e => e.Description).NotNull();
            RuleFor(e => e.UnitPrice).GreaterThanOrEqualTo(0);
        }
    }
}
