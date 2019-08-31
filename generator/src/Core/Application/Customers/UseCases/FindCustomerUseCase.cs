using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Domain;
using Optivem.Generator.Core.Application.Customers.Requests;
using Optivem.Generator.Core.Application.Customers.Responses;
using Optivem.Generator.Core.Domain.Customers.Entities;
using Optivem.Generator.Core.Domain.Customers.Repositories;
using Optivem.Generator.Core.Domain.Customers.ValueObjects;

namespace Optivem.Generator.Core.Application.Customers.UseCases
{
    public class FindCustomerUseCase : FindAggregateUseCase<ICustomerRepository, FindCustomerRequest, FindCustomerResponse, Customer, CustomerIdentity, int>
    {
        public FindCustomerUseCase(IUnitOfWork unitOfWork, IResponseMapper responseMapper)
            : base(unitOfWork, responseMapper)
        {
        }

        // TODO: VC: Common factory, optional, unless reflection --> i.e. virtual
        protected override CustomerIdentity GetIdentity(int id)
        {
            // TODO: VC: Do this via reflection
            return new CustomerIdentity(id);
        }
    }
}