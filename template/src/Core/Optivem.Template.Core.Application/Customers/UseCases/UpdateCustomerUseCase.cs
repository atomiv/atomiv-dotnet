using Optivem.Core.Application;
using Optivem.Core.Domain;
using Optivem.Template.Core.Application.Customers.Requests;
using Optivem.Template.Core.Application.Customers.Responses;
using Optivem.Template.Core.Domain.Customers;

namespace Optivem.Template.Core.Application.Customers.UseCases
{
    // TODO: VC: Perhaps have shared responses?

    public class UpdateCustomerUseCase : UpdateAggregateUseCase<UpdateCustomerRequest, UpdateCustomerResponse, Customer, CustomerIdentity, int>
    {
        public UpdateCustomerUseCase(IResponseMapper responseMapper, IUnitOfWork unitOfWork, ICrudRepository<Customer, CustomerIdentity> repository) 
            : base(responseMapper, unitOfWork, repository)
        {
        }

        protected override CustomerIdentity GetIdentity(int id)
        {
            return new CustomerIdentity(id);
        }

        protected override void Update(Customer aggregateRoot, UpdateCustomerRequest request)
        {
            aggregateRoot.FirstName = request.FirstName;
            aggregateRoot.LastName = request.LastName;
        }
    }
}
