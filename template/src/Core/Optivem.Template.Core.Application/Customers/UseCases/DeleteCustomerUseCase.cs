using Optivem.Core.Application;
using Optivem.Core.Domain;
using Optivem.Template.Core.Application.Customers.Requests;
using Optivem.Template.Core.Application.Customers.Responses;
using Optivem.Template.Core.Domain.Customers;

namespace Optivem.Template.Core.Application.Customers.UseCases
{
    public class DeleteCustomerUseCase : DeleteAggregateCase<DeleteCustomerRequest, DeleteCustomerResponse, Customer, CustomerIdentity, int>
    {
        public DeleteCustomerUseCase(IIdentityFactory<CustomerIdentity, int> identityFactory, IUnitOfWork unitOfWork, ICrudRepository<Customer, CustomerIdentity> repository) 
            : base(identityFactory, unitOfWork, repository)
        {
        }
    }
}
