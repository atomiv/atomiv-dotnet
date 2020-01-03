using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Application.Mapping;
using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Application.Orders.Queries.Repositories;
using Optivem.Template.Core.Domain.Orders;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Application.Orders.Queries
{
    public class ListOrdersQueryHandler : IRequestHandler<ListOrdersQuery, ListOrdersQueryResponse>
    {
        private readonly IOrderReadRepository _orderReadRepository;

        public ListOrdersQueryHandler(IOrderReadRepository orderReadRepository)
        {
            _orderReadRepository = orderReadRepository;
        }

        public Task<ListOrdersQueryResponse> HandleAsync(ListOrdersQuery request)
        {
            return _orderReadRepository.QueryAsync(request);
        }
    }
}