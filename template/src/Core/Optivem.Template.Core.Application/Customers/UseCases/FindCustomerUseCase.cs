using Optivem.Core.Application;
using Optivem.Core.Domain;
using Optivem.Template.Core.Application.Customers.Requests;
using Optivem.Template.Core.Application.Customers.Responses;
using Optivem.Template.Core.Domain;
using Optivem.Template.Core.Domain.Customers;

namespace Optivem.Template.Core.Application.Customers.UseCases
{
    public class FindCustomerUseCase : FindAggregateUseCase<IUnitOfWork, ICustomerRepository, FindCustomerRequest, FindCustomerResponse, Customer, CustomerIdentity, int>
    {
        public FindCustomerUseCase(ITransactionalUnitOfWorkFactory<IUnitOfWork> unitOfWorkFactory, IResponseMapper responseMapper)
            : base(unitOfWorkFactory, e => e.CustomerRepository, responseMapper)
        {
        }

        // TODO: VC: Common factory, optional, unless reflection
        protected override CustomerIdentity GetIdentity(int id)
        {
            // TODO: VC: Do this via reflection
            return new CustomerIdentity(id);
        }
    }
}