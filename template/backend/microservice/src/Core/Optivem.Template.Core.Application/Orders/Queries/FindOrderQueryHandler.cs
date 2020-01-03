using System.Threading.Tasks;
using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Application.Mapping;
using Optivem.Template.Core.Application.Orders.Repositories;
using Optivem.Template.Core.Domain.Orders;

namespace Optivem.Template.Core.Application.Orders.Queries
{
    public class FindOrderQueryHandler : IRequestHandler<FindOrderQuery, FindOrderQueryResponse>
    {
        private readonly IOrderReadRepository _orderReadRepository;

        public FindOrderQueryHandler(IMapper mapper, IOrderReadRepository orderReadRepository)
        {
            _orderReadRepository = orderReadRepository;
        }

        public async Task<FindOrderQueryResponse> HandleAsync(FindOrderQuery request)
        {
            var orderId = new OrderIdentity(request.Id);

            var response = await _orderReadRepository.QueryAsync(request);

            if (response == null)
            {
                throw new NotFoundRequestException();
            }

            return response;
        }
    }
}