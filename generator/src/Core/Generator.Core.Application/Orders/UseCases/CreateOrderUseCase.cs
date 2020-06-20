using Atomiv.Core.Application;
using Atomiv.Core.Application.Mappers;
using Atomiv.Core.Domain;
using Generator.Core.Application.Orders.Requests;
using Generator.Core.Application.Orders.Responses;
using Generator.Core.Domain.Orders;
using System;

namespace Generator.Core.Application.Orders.UseCases
{
    public class CreateOrderUseCase : CreateAggregateUseCase<IOrderRepository, CreateOrderRequest, CreateOrderResponse, Order, OrderIdentity, int>
    {
        public CreateOrderUseCase(IUseCaseMapper mapper, IUnitOfWork unitOfWork) 
            : base(mapper, unitOfWork)
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
