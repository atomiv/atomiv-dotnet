using Optivem.Framework.Core.Common;
using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Application.Orders.Requests;
using Optivem.Template.Core.Application.Orders.Responses;
using Optivem.Template.Core.Domain.Orders;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Application.Orders.UseCases
{
    public class BrowseOrdersUseCase : RequestHandler<BrowseOrdersRequest, BrowseOrdersResponse>
    {
        private readonly IOrderReadRepository _orderReadRepository;

        public BrowseOrdersUseCase(IMapper mapper, IOrderReadRepository orderReadRepository)
            : base(mapper)
        {
            _orderReadRepository = orderReadRepository;
        }

        public override async Task<BrowseOrdersResponse> HandleAsync(BrowseOrdersRequest request)
        {
            var pageQuery = new PageQuery(request.Page, request.Size);
            var pageResult = await _orderReadRepository.GetPageAsync(pageQuery);

            return Mapper.Map<PageReadModel<OrderHeaderReadModel>, BrowseOrdersResponse>(pageResult);
        }
    }
}