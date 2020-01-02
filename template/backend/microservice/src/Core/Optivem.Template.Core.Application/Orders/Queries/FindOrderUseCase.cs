using System.Threading.Tasks;
using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Application.Mapping;
using Optivem.Template.Core.Domain.Orders;

namespace Optivem.Template.Core.Application.Orders.Queries
{
    public class FindOrderUseCase : IRequestHandler<FindOrderQuery, FindOrderQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrderReadRepository _orderReadRepository;

        public FindOrderUseCase(IMapper mapper, IOrderReadRepository orderReadRepository)
        {
            _mapper = mapper;
            _orderReadRepository = orderReadRepository;
        }

        public async Task<FindOrderQueryResponse> HandleAsync(FindOrderQuery request)
        {
            var orderId = new OrderIdentity(request.Id);

            var order = await _orderReadRepository.FindAsync(orderId);

            if (order == null)
            {
                throw new NotFoundRequestException();
            }

            var response = _mapper.Map<Order, FindOrderQueryResponse>(order);
            return response;
        }
    }
}