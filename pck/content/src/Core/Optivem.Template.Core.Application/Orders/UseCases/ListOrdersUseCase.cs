using Optivem.Framework.Core.Common;
using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Application.Orders.Requests;
using Optivem.Template.Core.Application.Orders.Responses;
using Optivem.Template.Core.Domain.Orders;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Application.Orders.UseCases
{
    public class ListOrdersUseCase : RequestHandler<ListOrdersRequest, ListOrdersResponse>
    {
        private readonly IOrderReadRepository _orderReadRepository;

        public ListOrdersUseCase(IMapper mapper, IOrderReadRepository orderReadRepository)
            : base(mapper)
        {
            _orderReadRepository = orderReadRepository;
        }

        public override async Task<ListOrdersResponse> HandleAsync(ListOrdersRequest request)
        {
            var listResult = await _orderReadRepository.ListAsync();

            return Mapper.Map<ListReadModel<int>, ListOrdersResponse>(listResult);
        }
    }
}