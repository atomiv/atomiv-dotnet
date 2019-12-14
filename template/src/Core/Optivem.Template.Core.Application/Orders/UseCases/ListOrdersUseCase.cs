using Optivem.Framework.Core.Common;
using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Application.Orders.Requests;
using Optivem.Template.Core.Application.Orders.Responses;
using Optivem.Template.Core.Domain.Orders;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Application.Orders.UseCases
{
    public class ListOrdersUseCase : IRequestHandler<ListOrdersRequest, ListOrdersResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrderReadRepository _orderReadRepository;

        public ListOrdersUseCase(IMapper mapper, IOrderReadRepository orderReadRepository)
        {
            _mapper = mapper;
            _orderReadRepository = orderReadRepository;
        }

        public async Task<ListOrdersResponse> HandleAsync(ListOrdersRequest request)
        {
            var listResult = await _orderReadRepository.ListAsync();

            return _mapper.Map<ListReadModel<OrderIdNameReadModel>, ListOrdersResponse>(listResult);
        }
    }
}