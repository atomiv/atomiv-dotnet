using Atomiv.Core.Application;
using Atomiv.Core.Application.Mappers;
using Atomiv.Core.Domain;
using Generator.Core.Application.Orders.Requests;
using Generator.Core.Application.Orders.Responses;
using Generator.Core.Domain.Orders;

namespace Generator.Core.Application.Orders.UseCases
{
    public class CancelOrderUseCase : UpdateAggregateUseCase<IOrderRepository, CancelOrderRequest, CancelOrderResponse, Order, OrderIdentity, int>
    {
        public CancelOrderUseCase(IUseCaseMapper mapper, IUnitOfWork unitOfWork) 
            : base(mapper, unitOfWork)
        {
        }

        protected override void Update(Order aggregateRoot, CancelOrderRequest request)
        {
            aggregateRoot.Cancel();
        }
    }
}
