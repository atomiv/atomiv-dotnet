using System.Threading.Tasks;
using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Application.Orders.Requests;
using Optivem.Template.Core.Application.Orders.Responses;
using Optivem.Template.Core.Domain.Orders;

namespace Optivem.Template.Core.Application.Orders.UseCases
{
    public class ArchiveOrderUseCase : IRequestHandler<ArchiveOrderRequest, ArchiveOrderResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderRepository _orderRepository;

        public ArchiveOrderUseCase(IMapper mapper, IUnitOfWork unitOfWork, IOrderRepository orderRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _orderRepository = orderRepository;
        }

        public async Task<ArchiveOrderResponse> HandleAsync(ArchiveOrderRequest request)
        {
            var orderId = new OrderIdentity(request.Id);

            var order = await _orderRepository.FindAsync(orderId);

            if (order == null)
            {
                throw new NotFoundRequestException();
            }

            order.Archive();

            await _orderRepository.UpdateAsync(order);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<Order, ArchiveOrderResponse>(order);
        }
    }
}