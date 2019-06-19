using Optivem.Core.Application;
using Optivem.Infrastructure.MediatR;
using Optivem.Template.Core.Application.Customers.Requests;
using Optivem.Template.Core.Application.Customers.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Infrastructure.MediatR.Customers
{
    public class UpdateCustomerValidationPipelineBehavior : ValidationPipelineBehavior<UpdateCustomerRequest, UpdateCustomerResponse>
    {
        public UpdateCustomerValidationPipelineBehavior(IRequestValidationHandler<UpdateCustomerRequest> validationHandler) : base(validationHandler)
        {
        }
    }
}
