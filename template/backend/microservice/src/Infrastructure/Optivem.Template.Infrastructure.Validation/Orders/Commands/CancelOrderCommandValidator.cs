using Optivem.Framework.Infrastructure.FluentValidation;
using Optivem.Template.Core.Application.Orders.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Infrastructure.Validation.Orders.Commands
{
    public class CancelOrderCommandValidator : BaseValidator<CancelOrderCommand>
    {
        public CancelOrderCommandValidator()
        {

        }
    }
}
