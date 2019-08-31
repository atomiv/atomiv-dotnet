using Optivem.Framework.Core.Application;
using Optivem.Generator.Core.Application.Customers.Requests;
using Optivem.Generator.Core.Application.Customers.Responses;
using Optivem.Generator.Core.Domain.Customers.Entities;
using Optivem.Generator.Core.Domain.Customers.Repositories;
using Optivem.Generator.Core.Domain.Customers.ValueObjects;

namespace Optivem.Generator.Core.Application.Customers.UseCases
{
    public class ListCustomersUseCase : ListAggregatesUseCase<ICustomerRepository, ListCustomersRequest, ListCustomersResponse, ListCustomersRecordResponse, Customer, CustomerIdentity, int>
    {
        public ListCustomersUseCase(ICustomerRepository repository, ICollectionResponseMapper<Customer, ListCustomersResponse> responseMapper) 
            : base(repository, responseMapper)
        {
        }
    }
}