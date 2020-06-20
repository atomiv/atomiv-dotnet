using Atomiv.Core.Application;
using Atomiv.Core.Application.Mappers;
using Generator.Core.Application.Customers.Requests;
using Generator.Core.Application.Customers.Responses;
using Generator.Core.Domain.Customers;

namespace Generator.Core.Application.Customers.UseCases
{
    public class ListCustomersUseCase : ListAggregatesUseCase<ICustomerRepository, ListCustomersRequest, ListCustomersResponse, ListCustomersRecordResponse, Customer, CustomerIdentity, int>
    {
        public ListCustomersUseCase(IUseCaseMapper mapper, ICustomerRepository repository) 
            : base(mapper, repository)
        {
        }
    }
}