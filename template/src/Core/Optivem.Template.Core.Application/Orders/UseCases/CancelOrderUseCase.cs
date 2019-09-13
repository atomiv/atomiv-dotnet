using Optivem.Framework.Core.Application.UseCases;
using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Application.Orders.Requests;
using Optivem.Template.Core.Application.Orders.Responses;
using Optivem.Template.Core.Domain.Orders;

namespace Optivem.Template.Core.Application.Orders.UseCases
{
    public class CancelOrderUseCase : ExecuteAggregateUseCase<IOrderRepository, CancelOrderRequest, CancelOrderResponse, Order, OrderIdentity, int>
    {
        public CancelOrderUseCase(IMapper mapper, IUnitOfWork unitOfWork) 
            : base(mapper, unitOfWork)
        {
        }

        protected override void Execute(CancelOrderRequest request, Order aggregateRoot)
        {
            aggregateRoot.Cancel();
        }
    }
}
