using Optivem.Framework.Core.Application;
using Optivem.Template.Core.Application.Orders.Repositories;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Application.Orders.Queries
{
    public class BrowseOrdersQueryHandler : IRequestHandler<BrowseOrdersQuery, BrowseOrdersQueryResponse>
    {
        private readonly IOrderReadRepository _orderReadRepository;

        public BrowseOrdersQueryHandler(IOrderReadRepository orderReadRepository)
        {
            _orderReadRepository = orderReadRepository;
        }

        public Task<BrowseOrdersQueryResponse> HandleAsync(BrowseOrdersQuery request)
        {
            return _orderReadRepository.QueryAsync(request);
        }
    }
}