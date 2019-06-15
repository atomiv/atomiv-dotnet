using Optivem.Core.Application;
using Optivem.Core.Domain;
using Optivem.Template.Core.Application.Customers.Requests;
using Optivem.Template.Core.Application.Customers.Responses;
using Optivem.Template.Core.Domain.Customers;

namespace Optivem.Template.Core.Application.Customers.UseCases
{
    public class DeleteCustomerUseCase : DeleteAggregateCase<DeleteCustomerRequest, DeleteCustomerResponse, Customer, CustomerIdentity, int>
    {
        public DeleteCustomerUseCase(IUnitOfWork unitOfWork, ICrudRepository<Customer, CustomerIdentity> repository) 
            : base(unitOfWork, repository)
        {
        }

        protected override CustomerIdentity GetIdentity(int id)
        {
            return new CustomerIdentity(id);
        }
    }
}
