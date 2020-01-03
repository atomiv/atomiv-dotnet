using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Application.Mapping;
using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Domain.Orders;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Application.Orders.Queries
{
    public class BrowseOrdersUseCase : IRequestHandler<BrowseOrdersQuery, BrowseOrdersQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrderReadRepository _orderReadRepository;

        public BrowseOrdersUseCase(IMapper mapper, IOrderReadRepository orderReadRepository)
        {
            _mapper = mapper;
            _orderReadRepository = orderReadRepository;
        }

        public async Task<BrowseOrdersQueryResponse> HandleAsync(BrowseOrdersQuery request)
        {
            var pageQuery = new PageQuery(request.Page, request.Size);
            var pageResult = await _orderReadRepository.GetPageAsync(pageQuery);

            return _mapper.Map<PageReadModel<OrderHeaderReadModel>, BrowseOrdersQueryResponse>(pageResult);
        }
    }
}