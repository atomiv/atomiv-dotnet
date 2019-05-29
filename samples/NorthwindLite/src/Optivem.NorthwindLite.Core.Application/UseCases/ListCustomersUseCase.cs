using Optivem.Core.Application;
using Optivem.Core.Domain;
using Optivem.NorthwindLite.Core.Application.Interface.Customers.Queries.BrowseAll;
using Optivem.NorthwindLite.Core.Application.Interface.Customers.Queries.List;
using Optivem.NorthwindLite.Core.Domain.Entities;
using Optivem.NorthwindLite.Core.Domain.Identities;

namespace Optivem.NorthwindLite.Core.Application.UseCases.Customers
{
    public class ListCustomersUseCase : ListUseCase<ListCustomersRequest, ListCustomersResponse, ListCustomersElementResponse, Customer, CustomerIdentity, int>
    {
        public ListCustomersUseCase(IResponseMapper responseMapper, IReadonlyCrudRepository<Customer, CustomerIdentity> repository) : base(responseMapper, repository)
        {
        }
    }
}