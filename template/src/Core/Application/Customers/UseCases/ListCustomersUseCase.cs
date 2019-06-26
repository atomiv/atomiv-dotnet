using Optivem.Framework.Core.Application;
using Optivem.Template.Core.Application.Customers.Requests;
using Optivem.Template.Core.Application.Customers.Responses;
using Optivem.Template.Core.Domain.Customers.Entities;
using Optivem.Template.Core.Domain.Customers.Repositories;
using Optivem.Template.Core.Domain.Customers.ValueObjects;

namespace Optivem.Template.Core.Application.Customers.UseCases
{
    public class ListCustomersUseCase : ListAggregatesUseCase<ICustomerRepository, ListCustomersRequest, ListCustomersResponse, ListCustomersRecordResponse, Customer, CustomerIdentity, int>
    {
        public ListCustomersUseCase(ICustomerRepository repository, ICollectionResponseMapper<Customer, ListCustomersResponse> responseMapper) 
            : base(repository, responseMapper)
        {
        }
    }
}