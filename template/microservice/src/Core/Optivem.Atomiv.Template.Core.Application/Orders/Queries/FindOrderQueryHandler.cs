using System.Threading.Tasks;
using Optivem.Atomiv.Core.Application;
using Optivem.Atomiv.Core.Application.Mapping;
using Optivem.Atomiv.Template.Core.Application.Orders.Repositories;

namespace Optivem.Atomiv.Template.Core.Application.Orders.Queries
{
    public class FindOrderQueryHandler : IRequestHandler<FindOrderQuery, FindOrderQueryResponse>
    {
        private readonly IOrderQueryRepository _orderReadRepository;

        public FindOrderQueryHandler(IMapper mapper, IOrderQueryRepository orderReadRepository)
        {
            _orderReadRepository = orderReadRepository;
        }

        public async Task<FindOrderQueryResponse> HandleAsync(FindOrderQuery request)
        {
            var response = await _orderReadRepository.QueryAsync(request);

            return response;
        }
    }
}