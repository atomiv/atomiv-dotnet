using Optivem.Atomiv.Core.Application;
using Optivem.Atomiv.Template.Core.Application.Orders.Repositories;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Template.Core.Application.Orders.Queries
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