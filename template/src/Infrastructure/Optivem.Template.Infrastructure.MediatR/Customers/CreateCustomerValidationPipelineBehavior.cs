using Optivem.Core.Application;
using Optivem.Infrastructure.MediatR;
using Optivem.Template.Core.Application.Customers.Requests;
using Optivem.Template.Core.Application.Customers.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Infrastructure.MediatR.Customers
{
    public class CreateCustomerValidationPipelineBehavior : ValidationPipelineBehavior<CreateCustomerRequest, CreateCustomerResponse>
    {
        public CreateCustomerValidationPipelineBehavior(IRequestValidationHandler<CreateCustomerRequest> validationHandler) : base(validationHandler)
        {
        }
    }
}
