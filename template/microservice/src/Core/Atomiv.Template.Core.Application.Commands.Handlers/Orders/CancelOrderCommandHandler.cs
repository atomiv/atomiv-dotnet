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
        private readonly IUnitOfWork _unitOfWork;

        public CancelOrderCommandHandler(IMapper mapper, 
            IOrderRepository orderRepository,
            IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CancelOrderCommandResponse> HandleAsync(CancelOrderCommand request)
        {
            var orderId = new OrderIdentity(request.Id);

            var order = await _orderRepository.FindAsync(orderId);

            if(order == null)
            {
                throw new ExistenceException();
            }

            order.Cancel();

            await _orderRepository.UpdateAsync(order);

            await _unitOfWork.CommitAsync();

            return _mapper.Map<Order, CancelOrderCommandResponse>(order);
        }
    }
}