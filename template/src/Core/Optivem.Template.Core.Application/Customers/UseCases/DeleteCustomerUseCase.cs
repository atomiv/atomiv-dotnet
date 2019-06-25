using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Domain.Customers;

namespace Optivem.Template.Core.Application.Customers
{
    public class DeleteCustomerUseCase : DeleteAggregateCase<ICustomerRepository, DeleteCustomerRequest, DeleteCustomerResponse, Customer, CustomerIdentity, int>
    {
        public DeleteCustomerUseCase(IUnitOfWork unitOfWork, IIdentityFactory<CustomerIdentity, int> identityFactory) 
            : base(unitOfWork, identityFactory)
        {
        }
    }
}
