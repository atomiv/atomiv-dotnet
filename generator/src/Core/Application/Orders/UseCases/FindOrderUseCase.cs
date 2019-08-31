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
    public class FindOrderUseCase : FindAggregateUseCase<IOrderRepository, FindOrderRequest, FindOrderResponse, Order, OrderIdentity, int>
    {
        public FindOrderUseCase(IUnitOfWork unitOfWork, IResponseMapper responseMapper) : base(unitOfWork, responseMapper)
        {
        }

        protected override OrderIdentity GetIdentity(int id)
        {
            throw new NotImplementedException();
        }
    }
}
