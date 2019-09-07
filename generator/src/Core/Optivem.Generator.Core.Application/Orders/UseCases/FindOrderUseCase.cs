using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Application.Mappers;
using Optivem.Framework.Core.Domain;
using Optivem.Generator.Core.Application.Orders.Requests;
using Optivem.Generator.Core.Application.Orders.Responses;
using Optivem.Generator.Core.Domain.Orders;
using System;

namespace Optivem.Generator.Core.Application.Orders.UseCases
{
    public class FindOrderUseCase : FindAggregateUseCase<IOrderRepository, FindOrderRequest, FindOrderResponse, Order, OrderIdentity, int>
    {
        public FindOrderUseCase(IUseCaseMapper mapper, IUnitOfWork unitOfWork) 
            : base(mapper, unitOfWork)
        {
        }
    }
}
