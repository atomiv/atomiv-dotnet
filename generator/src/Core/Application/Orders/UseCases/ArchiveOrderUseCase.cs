using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Application.Mappers;
using Optivem.Framework.Core.Domain;
using Optivem.Generator.Core.Application.Orders.Requests;
using Optivem.Generator.Core.Application.Orders.Responses;
using Optivem.Generator.Core.Domain.Orders;

namespace Optivem.Generator.Core.Application.Orders.UseCases
{
    public class ArchiveOrderUseCase : UpdateAggregateUseCase<IOrderRepository, ArchiveOrderRequest, ArchiveOrderResponse, Order, OrderIdentity, int>
    {
        public ArchiveOrderUseCase(IUseCaseMapper mapper, IUnitOfWork unitOfWork) 
            : base(mapper, unitOfWork)
        {
        }

        protected override void Update(Order aggregateRoot, ArchiveOrderRequest request)
        {
            aggregateRoot.Archive();
        }
    }
}
