using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Domain;
using Optivem.Generator.Core.Application.Orders.Requests;
using Optivem.Generator.Core.Application.Orders.Responses;
using Optivem.Generator.Core.Domain.Orders.Entities;
using Optivem.Generator.Core.Domain.Orders.Repositories;
using Optivem.Generator.Core.Domain.Orders.ValueObjects;

namespace Optivem.Generator.Core.Application.Orders.UseCases
{
    // TODO: VC: Base could be like a custom update... with action injected

    public class ArchiveOrderUseCase : UpdateAggregateUseCase<IOrderRepository, ArchiveOrderRequest, ArchiveOrderResponse, Order, OrderIdentity, int>
    {
        public ArchiveOrderUseCase(IUnitOfWork unitOfWork, IResponseMapper responseMapper) : base(unitOfWork, responseMapper)
        {
        }

        protected override OrderIdentity GetIdentity(int id)
        {
            return new OrderIdentity(id);
        }

        protected override void Update(Order aggregateRoot, ArchiveOrderRequest request)
        {
            aggregateRoot.Archive();
        }
    }
}
