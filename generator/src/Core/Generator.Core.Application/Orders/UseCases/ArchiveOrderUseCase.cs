using Atomiv.Core.Application;
using Atomiv.Core.Application.Mappers;
using Atomiv.Core.Domain;
using Generator.Core.Application.Orders.Requests;
using Generator.Core.Application.Orders.Responses;
using Generator.Core.Domain.Orders;

namespace Generator.Core.Application.Orders.UseCases
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
