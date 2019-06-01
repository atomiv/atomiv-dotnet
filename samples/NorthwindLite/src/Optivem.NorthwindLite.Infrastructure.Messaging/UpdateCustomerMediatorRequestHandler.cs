using Optivem.Core.Application;
using Optivem.Infrastructure.MediatR;
using Optivem.NorthwindLite.Core.Application.Interface.Customers.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.NorthwindLite.Infrastructure.Messaging
{
    public class UpdateCustomerMediatorRequestHandler : MediatorRequestHandler<UpdateCustomerRequest, UpdateCustomerResponse>
    {
        public UpdateCustomerMediatorRequestHandler(IUseCase<UpdateCustomerRequest, UpdateCustomerResponse> useCase) : base(useCase)
        {
        }
    }
}
