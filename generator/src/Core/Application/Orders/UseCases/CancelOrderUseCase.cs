using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Application.Mappers;
using Optivem.Framework.Core.Domain;
using Optivem.Generator.Core.Application.Orders.Requests;
using Optivem.Generator.Core.Application.Orders.Responses;
using Optivem.Generator.Core.Domain.Orders;

namespace Optivem.Generator.Core.Application.Orders.UseCases
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
