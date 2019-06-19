using Optivem.Core.Application;
using Optivem.Core.Domain;
using Optivem.Template.Core.Application.Customers.Requests;
using Optivem.Template.Core.Application.Customers.Responses;
using Optivem.Template.Core.Domain;
using Optivem.Template.Core.Domain.Customers;

namespace Optivem.Template.Core.Application.Customers.UseCases
{
    public class ListCustomersUseCase : ListAggregatesUseCase<IUnitOfWork, ICustomerRepository, ListCustomersRequest, ListCustomersResponse, ListCustomersElementResponse, Customer, CustomerIdentity, int>
    {
        public ListCustomersUseCase(ITransactionalUnitOfWorkFactory<IUnitOfWork> unitOfWorkFactory, IResponseMapper responseMapper) 
            : base(unitOfWorkFactory, e => e.CustomerRepository, responseMapper)
        {
        }
    }
}