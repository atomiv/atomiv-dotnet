using Atomiv.Core.Application;
using Atomiv.Core.Application.Mappers;
using Atomiv.Core.Domain;
using Generator.Core.Application.Orders.Requests;
using Generator.Core.Application.Orders.Responses;
using Generator.Core.Domain.Orders;
using System;

namespace Generator.Core.Application.Orders.UseCases
{
    public class FindOrderUseCase : FindAggregateUseCase<IOrderRepository, FindOrderRequest, FindOrderResponse, Order, OrderIdentity, int>
    {
        public FindOrderUseCase(IUseCaseMapper mapper, IUnitOfWork unitOfWork) 
            : base(mapper, unitOfWork)
        {
        }
    }
}
