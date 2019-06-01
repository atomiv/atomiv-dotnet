using Optivem.Core.Application;
using Optivem.Infrastructure.Messaging.MediatR;
using Optivem.NorthwindLite.Core.Application.Interface.Customers.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.NorthwindLite.Infrastructure.Messaging
{
    public class DeleteCustomerMediatorRequestHandler : MediatorRequestHandler<DeleteCustomerRequest, DeleteCustomerResponse>
    {
        public DeleteCustomerMediatorRequestHandler(IUseCase<DeleteCustomerRequest, DeleteCustomerResponse> useCase) : base(useCase)
        {
        }
    }
}
