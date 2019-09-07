using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Application.Mappers;
using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Application.Orders.Requests;
using Optivem.Template.Core.Application.Orders.Responses;
using Optivem.Template.Core.Domain.Orders;

namespace Optivem.Template.Core.Application.Orders.UseCases
{
    public class SubmitOrderUseCase : UpdateAggregateUseCase<IOrderRepository, SubmitOrderRequest, SubmitOrderResponse, Order, OrderIdentity, int>
    {
        public SubmitOrderUseCase(IUseCaseMapper mapper, IUnitOfWork unitOfWork) 
            : base(mapper, unitOfWork)
        {
        }

        protected override void Update(Order aggregateRoot, SubmitOrderRequest request)
        {
            aggregateRoot.Submit();
        }
    }
}
