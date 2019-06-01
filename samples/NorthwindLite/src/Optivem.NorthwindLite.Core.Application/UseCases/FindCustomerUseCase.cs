using Optivem.Core.Application;
using Optivem.Core.Domain;
using Optivem.NorthwindLite.Core.Application.Interface.Customers.Retrieve;
using Optivem.NorthwindLite.Core.Application.Interface.Requests.Customers;
using Optivem.NorthwindLite.Core.Domain.Entities;
using Optivem.NorthwindLite.Core.Domain.Identities;

namespace Optivem.NorthwindLite.Core.Application.UseCases
{
    public class FindCustomerUseCase : FindUseCase<FindCustomerRequest, FindCustomerResponse, Customer, CustomerIdentity, int>
    {
        public FindCustomerUseCase(IResponseMapper responseMapper, IReadonlyCrudRepository<Customer, CustomerIdentity> repository)
            : base(responseMapper, repository)
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