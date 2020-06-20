using Atomiv.Core.Application;
using Atomiv.Template.Core.Application.Commands.Orders;
using Atomiv.Template.Core.Domain.Orders;
using System.Threading.Tasks;

namespace Atomiv.Template.Core.Application.Commands.Handlers.Orders
{
    public class CancelOrderCommandHandler : IRequestHandler<CancelOrderCommand, CancelOrderCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;

        public CancelOrderCommandHandler(IMapper mapper, IOrderRepository orderRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        public async Task<CancelOrderCommandResponse> HandleAsync(CancelOrderCommand request)
        {
            var orderId = new OrderIdentity(request.Id);

            var order = await _orderRepository.FindAsync(orderId);

            order.Cancel();

            await _orderRepository.UpdateAsync(order);
            return _mapper.Map<Order, CancelOrderCommandResponse>(order);
        }
    }
}