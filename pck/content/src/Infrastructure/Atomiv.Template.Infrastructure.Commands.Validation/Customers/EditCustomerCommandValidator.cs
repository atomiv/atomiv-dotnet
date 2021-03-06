﻿using FluentValidation;
using Atomiv.Infrastructure.FluentValidation;
using Atomiv.Template.Core.Application.Commands.Customers;

namespace Atomiv.Template.Infrastructure.Commands.Validation.Customers
{
    public class EditCustomerCommandValidator : BaseValidator<EditCustomerCommand>
    {
        public EditCustomerCommandValidator()
        {
            RuleFor(e => e.Id)
                .NotEmpty()
                .WithErrorCode(ValidationErrorCodes.NotFound);

            RuleFor(e => e.FirstName)
                .NotNull();

            RuleFor(e => e.LastName)
                .NotNull();
        }
    }
}