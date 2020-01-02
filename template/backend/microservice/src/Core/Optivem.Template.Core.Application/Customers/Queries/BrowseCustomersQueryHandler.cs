using System.Threading.Tasks;
using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Application.Mapping;
using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Domain.Customers;

namespace Optivem.Template.Core.Application.Customers.Queries
{
    public class BrowseCustomersQueryHandler : IRequestHandler<BrowseCustomersQuery, BrowseCustomersQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerReadRepository _customerReadRepository;

        public BrowseCustomersQueryHandler(IMapper mapper, ICustomerReadRepository customerReadRepository)
        {
            _mapper = mapper;
            _customerReadRepository = customerReadRepository;
        }

        public async Task<BrowseCustomersQueryResponse> HandleAsync(BrowseCustomersQuery request)
        {
            var pageQuery = new PageQuery(request.Page, request.Size);
            var pageResult = await _customerReadRepository.GetPageAsync(pageQuery);

            return _mapper.Map<PageReadModel<CustomerHeaderReadModel>, BrowseCustomersQueryResponse>(pageResult);
        }
    }
}