using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Common.Mapping;
using Optivem.Template.Core.Application.Customers.Requests;
using Optivem.Template.Core.Application.Customers.Responses;
using Optivem.Template.Core.Domain.Customers;

namespace Optivem.Template.Core.Application.Customers.UseCases
{
    public class BrowseCustomersUseCase : BrowseAggregatesUseCase<ICustomerRepository, BrowseCustomersRequest, BrowseCustomersResponse, BrowseCustomersRecordResponse, Customer, CustomerIdentity, int>
    {
        public BrowseCustomersUseCase(IMapper mapper, ICustomerRepository repository) : base(mapper, repository)
        {
        }
    }
}