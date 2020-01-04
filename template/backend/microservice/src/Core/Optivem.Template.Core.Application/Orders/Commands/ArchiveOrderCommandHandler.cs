using System.Threading.Tasks;
using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Application.Mapping;
using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Domain.Orders;

namespace Optivem.Template.Core.Application.Orders.Commands
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

            if (order == null)
            {
                throw new ExistenceException();
            }

            order.Archive();

            await _orderRepository.UpdateAsync(order);
            return _mapper.Map<Order, ArchiveOrderCommandResponse>(order);
        }
    }
}