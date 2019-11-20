using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Common;
using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Application.Orders.Requests;
using Optivem.Template.Core.Application.Orders.Responses;
using Optivem.Template.Core.Domain.Orders;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Application.Orders.UseCases
{
    public class CancelOrderUseCase : RequestHandler<CancelOrderRequest, CancelOrderResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderRepository _orderRepository;

        public CancelOrderUseCase(IMapper mapper, IUnitOfWork unitOfWork, IOrderRepository orderRepository)
            : base(mapper)
        {
            _unitOfWork = unitOfWork;
            _orderRepository = orderRepository;
        }

        public override async Task<CancelOrderResponse> HandleAsync(CancelOrderRequest request)
        {
            var orderId = new OrderIdentity(request.Id);

            var order = await _orderRepository.FindAsync(orderId);

            if (order == null)
            {
                throw new NotFoundRequestException();
            }

            order.Cancel();

            order = await _orderRepository.UpdateAsync(order);
            await _unitOfWork.SaveChangesAsync();
            return Mapper.Map<Order, CancelOrderResponse>(order);
        }
    }
}