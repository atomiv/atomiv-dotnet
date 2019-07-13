using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Application.Orders.Requests;
using Optivem.Template.Core.Application.Orders.Responses;
using Optivem.Template.Core.Domain.Orders.Entities;
using Optivem.Template.Core.Domain.Orders.Repositories;
using Optivem.Template.Core.Domain.Orders.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Core.Application.Orders.UseCases
{
    public class CreateOrderUseCase : CreateAggregateUseCase<IOrderRepository, CreateOrderRequest, CreateOrderResponse, Order, OrderIdentity, int>
    {
        public CreateOrderUseCase(IUnitOfWork unitOfWork, IResponseMapper<Order, CreateOrderResponse> responseMapper) : base(unitOfWork, responseMapper)
        {
        }

        protected override Order CreateAggregateRoot(CreateOrderRequest request)
        {
            throw new NotImplementedException();
        }

        protected override Order CreateAggregateRoot(Order aggregateRoot, OrderIdentity identity)
        {
            throw new NotImplementedException();
        }
    }
}
