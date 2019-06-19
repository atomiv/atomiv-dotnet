using Optivem.Core.Application;
using Optivem.Core.Domain;
using Optivem.Template.Core.Application.Customers.Requests;
using Optivem.Template.Core.Application.Customers.Responses;
using Optivem.Template.Core.Domain;
using Optivem.Template.Core.Domain.Customers;

namespace Optivem.Template.Core.Application.Customers.UseCases
{
    public class DeleteCustomerUseCase : DeleteAggregateCase<IUnitOfWork, ICustomerRepository, DeleteCustomerRequest, DeleteCustomerResponse, Customer, CustomerIdentity, int>
    {
        public DeleteCustomerUseCase(ITransactionalUnitOfWorkFactory<IUnitOfWork> unitOfWorkFactory, IIdentityFactory<CustomerIdentity, int> identityFactory) 
            : base(unitOfWorkFactory, e => e.CustomerRepository, identityFactory)
        {
        }
    }
}
