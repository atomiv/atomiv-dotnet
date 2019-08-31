using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Domain;
using Optivem.Generator.Core.Application.Orders.Requests;
using Optivem.Generator.Core.Application.Orders.Responses;
using Optivem.Generator.Core.Domain.Orders.Entities;
using Optivem.Generator.Core.Domain.Orders.Repositories;
using Optivem.Generator.Core.Domain.Orders.ValueObjects;
using System;

namespace Optivem.Generator.Core.Application.Orders.UseCases
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
