using System.Threading.Tasks;
using Atomiv.Core.Application;
using Atomiv.Template.Core.Application.Commands.Orders;
using Atomiv.Template.Core.Domain.Orders;

namespace Atomiv.Template.Core.Application.Commands.Handlers.Orders
{
    public class ArchiveOrderCommandHandler : IRequestHandler<ArchiveOrderCommand, ArchiveOrderCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;

        public ArchiveOrderCommandHandler(IMapper mapper, IOrderRepository orderRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        public async Task<ArchiveOrderCommandResponse> HandleAsync(ArchiveOrderCommand request)
        {
            var orderId = new OrderIdentity(request.Id);

            var order = await _orderRepository.FindAsync(orderId);

            order.Archive();

            await _orderRepository.UpdateAsync(order);
            return _mapper.Map<Order, ArchiveOrderCommandResponse>(order);
        }
    }
}