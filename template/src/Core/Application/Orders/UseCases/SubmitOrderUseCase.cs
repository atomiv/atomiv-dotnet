using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Application.Orders.Requests;
using Optivem.Template.Core.Application.Orders.Responses;
using Optivem.Template.Core.Domain.Orders.Entities;
using Optivem.Template.Core.Domain.Orders.Repositories;
using Optivem.Template.Core.Domain.Orders.ValueObjects;

namespace Optivem.Template.Core.Application.Orders.UseCases
{
    public class SubmitOrderUseCase : UpdateAggregateUseCase<IOrderRepository, SubmitOrderRequest, SubmitOrderResponse, Order, OrderIdentity, int>
    {
        public SubmitOrderUseCase(IUnitOfWork unitOfWork, IResponseMapper responseMapper) : base(unitOfWork, responseMapper)
        {
        }

        protected override OrderIdentity GetIdentity(int id)
        {
            return new OrderIdentity(id);
        }

        protected override void Update(Order aggregateRoot, SubmitOrderRequest request)
        {
            aggregateRoot.Submit();
        }
    }
}
