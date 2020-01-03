using System.Threading.Tasks;
using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Application.Mapping;
using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Application.Customers.Queries;
using Optivem.Template.Core.Application.Customers.Queries.Repositories;

namespace Optivem.Template.Core.Infrastructure.Persistence.QueryHandlers
{
    public class ListCustomersQueryHandler : IRequestHandler<ListCustomersQuery, ListCustomersQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerReadRepository _customerReadRepository;

        public ListCustomersQueryHandler(IMapper mapper, ICustomerReadRepository customerReadRepository)
        {
            _mapper = mapper;
            _customerReadRepository = customerReadRepository;
        }

        public Task<ListCustomersQueryResponse> HandleAsync(ListCustomersQuery request)
        {
            return _customerReadRepository.QueryAsync(request);
        }
    }
}