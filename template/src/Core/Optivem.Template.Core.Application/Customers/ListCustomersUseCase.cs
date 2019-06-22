using Optivem.Core.Application;
using Optivem.Core.Domain;
using Optivem.Template.Core.Domain.Customers;

namespace Optivem.Template.Core.Application.Customers
{
    public class ListCustomersUseCase : ListAggregatesUseCase<ICustomerRepository, ListCustomersRequest, ListCustomersResponse, ListCustomersRecordResponse, Customer, CustomerIdentity, int>
    {
        public ListCustomersUseCase(IUnitOfWork unitOfWork, IResponseMapper responseMapper) 
            : base(unitOfWork, responseMapper)
        {
        }
    }
}