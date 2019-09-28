using FluentValidation;
using Optivem.Framework.Infrastructure.FluentValidation;
using Optivem.Template.Core.Application.Products.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Infrastructure.FluentValidation.Products
{
    public class UpdateProductRequestValidator : BaseValidator<UpdateProductRequest>
    {
        public UpdateProductRequestValidator()
        {
            RuleFor(e => e.Description).NotNull();
            RuleFor(e => e.UnitPrice).GreaterThan(0);
        }
    }
}
