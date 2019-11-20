using System.Threading.Tasks;
using Optivem.Framework.Core.Common;
using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Application.Customers.Requests;
using Optivem.Template.Core.Application.Customers.Responses;
using Optivem.Template.Core.Domain.Customers;

namespace Optivem.Template.Core.Application.Customers.UseCases
{
    public class BrowseCustomersUseCase : RequestHandler<BrowseCustomersRequest, BrowseCustomersResponse>
    {
        private readonly ICustomerReadRepository _customerReadRepository;

        public BrowseCustomersUseCase(IMapper mapper, ICustomerReadRepository customerReadRepository)
            : base(mapper)
        {
            _customerReadRepository = customerReadRepository;
        }

        public override async Task<BrowseCustomersResponse> HandleAsync(BrowseCustomersRequest request)
        {
            var pageQuery = new PageQuery(request.Page, request.Size);
            var pageResult = await _customerReadRepository.GetPageAsync(pageQuery);

            return Mapper.Map<PageReadModel<CustomerHeaderReadModel>, BrowseCustomersResponse>(pageResult);
        }
    }
}