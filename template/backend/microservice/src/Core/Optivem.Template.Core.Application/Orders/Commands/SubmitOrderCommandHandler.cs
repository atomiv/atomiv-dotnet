using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Application.Mapping;
using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Domain.Orders;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Application.Orders.Commands
{
    public class SubmitOrderCommandHandler : IRequestHandler<SubmitOrderCommand, SubmitOrderCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderRepository _orderRepository;

        public SubmitOrderCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IOrderRepository orderRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _orderRepository = orderRepository;
        }

        public async Task<SubmitOrderCommandResponse> HandleAsync(SubmitOrderCommand request)
        {
            var orderId = new OrderIdentity(request.Id);

            var order = await _orderRepository.FindAsync(orderId);

            if (order == null)
            {
                throw new NotFoundRequestException();
            }

            order.Submit();

            await _orderRepository.UpdateAsync(order);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<Order, SubmitOrderCommandResponse>(order);
        }
    }
}