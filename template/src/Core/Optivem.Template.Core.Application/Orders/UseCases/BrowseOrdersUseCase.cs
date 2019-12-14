using Optivem.Framework.Core.Common;
using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Application.Orders.Requests;
using Optivem.Template.Core.Application.Orders.Responses;
using Optivem.Template.Core.Domain.Orders;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Application.Orders.UseCases
{
    public class BrowseOrdersUseCase : IRequestHandler<BrowseOrdersRequest, BrowseOrdersResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrderReadRepository _orderReadRepository;

        public BrowseOrdersUseCase(IMapper mapper, IOrderReadRepository orderReadRepository)
        {
            _mapper = mapper;
            _orderReadRepository = orderReadRepository;
        }

        public async Task<BrowseOrdersResponse> HandleAsync(BrowseOrdersRequest request)
        {
            var pageQuery = new PageQuery(request.Page, request.Size);
            var pageResult = await _orderReadRepository.GetPageAsync(pageQuery);

            return _mapper.Map<PageReadModel<OrderHeaderReadModel>, BrowseOrdersResponse>(pageResult);
        }
    }
}