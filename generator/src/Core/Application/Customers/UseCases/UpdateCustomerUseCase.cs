using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Domain;
using Optivem.Generator.Core.Application.Customers.Requests;
using Optivem.Generator.Core.Application.Customers.Responses;
using Optivem.Generator.Core.Domain.Customers.Entities;
using Optivem.Generator.Core.Domain.Customers.Repositories;
using Optivem.Generator.Core.Domain.Customers.ValueObjects;

namespace Optivem.Generator.Core.Application.Customers.UseCases
{
    // TODO: VC: Perhaps have shared responses?

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
