using Optivem.Core.Application;
using Optivem.Core.Domain;
using Optivem.NorthwindLite.Core.Application.Customers.Requests;
using Optivem.NorthwindLite.Core.Application.Customers.Responses;
using Optivem.NorthwindLite.Core.Domain.Customers;

namespace Optivem.NorthwindLite.Core.Application.Customers.UseCases
{
    public class ListCustomersUseCase : ListAggregatesUseCase<ListCustomersRequest, ListCustomersResponse, ListCustomersElementResponse, Customer, CustomerIdentity, int>
    {
        public ListCustomersUseCase(IResponseMapper responseMapper, IReadonlyCrudRepository<Customer, CustomerIdentity> repository) : base(responseMapper, repository)
        {
        }
    }
}