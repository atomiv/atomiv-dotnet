using Optivem.Atomiv.Core.Application;
using Optivem.Atomiv.Template.Core.Application.Orders.Repositories;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Template.Core.Application.Orders.Queries
{
    public class FilterOrdersQueryHandler : IRequestHandler<FilterOrdersQuery, FilterOrdersQueryResponse>
    {
        private readonly IOrderQueryRepository _orderReadRepository;

        public FilterOrdersQueryHandler(IOrderQueryRepository orderReadRepository)
        {
            _orderReadRepository = orderReadRepository;
        }

        public Task<FilterOrdersQueryResponse> HandleAsync(FilterOrdersQuery request)
        {
            return _orderReadRepository.QueryAsync(request);
        }
    }
}