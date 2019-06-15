using Optivem.Core.Application;
using Optivem.Core.Domain;
using Optivem.Template.Core.Application.Customers.Requests;
using Optivem.Template.Core.Application.Customers.Responses;
using Optivem.Template.Core.Domain.Customers;

namespace Optivem.Template.Core.Application.Customers.UseCases
{
    public class ListCustomersUseCase : ListAggregatesUseCase<ListCustomersRequest, ListCustomersResponse, ListCustomersElementResponse, Customer, CustomerIdentity, int>
    {
        public ListCustomersUseCase(IResponseMapper responseMapper, IReadonlyRepository<Customer, CustomerIdentity> repository) : base(responseMapper, repository)
        {
        }
    }
}