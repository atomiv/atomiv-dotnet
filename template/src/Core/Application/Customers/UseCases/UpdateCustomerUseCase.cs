using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Application.Customers.Requests;
using Optivem.Template.Core.Application.Customers.Responses;
using Optivem.Template.Core.Domain.Customers;

namespace Optivem.Template.Core.Application.Customers.UseCases
{
    public class UpdateCustomerUseCase : UpdateAggregateUseCase<ICustomerRepository, UpdateCustomerRequest, UpdateCustomerResponse, Customer, CustomerIdentity, int>
    {
        public UpdateCustomerUseCase(IUnitOfWork unitOfWork, IResponseMapper responseMapper) 
            : base(unitOfWork, responseMapper)
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
