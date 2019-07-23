using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Application.Orders.Requests;
using Optivem.Template.Core.Application.Orders.Responses;
using Optivem.Template.Core.Domain.Orders.Entities;
using Optivem.Template.Core.Domain.Orders.Repositories;
using Optivem.Template.Core.Domain.Orders.ValueObjects;
using System;

namespace Optivem.Template.Core.Application.Orders.UseCases
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
