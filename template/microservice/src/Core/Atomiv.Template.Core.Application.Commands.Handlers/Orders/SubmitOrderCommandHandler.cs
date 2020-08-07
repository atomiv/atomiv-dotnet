using Atomiv.Core.Application;
using Atomiv.Template.Core.Application.Commands.Orders;
using Atomiv.Template.Core.Domain.Orders;
using System.Threading.Tasks;

namespace Atomiv.Template.Core.Application.Commands.Handlers.Orders
{
    public class SubmitOrderCommandHandler : ICommandHandler<SubmitOrderCommand, SubmitOrderCommandResponse>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public SubmitOrderCommandHandler(IOrderRepository orderRepository, 
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _orderRepository = orderRepository;
        }

        public async Task<SubmitOrderCommandResponse> HandleAsync(SubmitOrderCommand request)
        {
            var orderId = new OrderIdentity(request.Id);

            var order = await _orderRepository.FindAsync(orderId);

            if(order == null)
            {
                throw new ExistenceException();
            }

            order.Submit();

            await _orderRepository.UpdateAsync(order);

            await _unitOfWork.CommitAsync();
            
            return _mapper.Map<Order, SubmitOrderCommandResponse>(order);
        }
    }
}