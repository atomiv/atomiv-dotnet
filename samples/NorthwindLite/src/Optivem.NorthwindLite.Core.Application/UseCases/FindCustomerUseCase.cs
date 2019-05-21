using Optivem.Core.Application;
using Optivem.Core.Domain;
using Optivem.NorthwindLite.Core.Application.Interface.Customers.Retrieve;
using Optivem.NorthwindLite.Core.Application.Interface.Requests.Customers;
using Optivem.NorthwindLite.Core.Domain.Entities;

namespace Optivem.NorthwindLite.Core.Application.UseCases
{
    public class FindCustomerUseCase : FindUseCase<FindCustomerRequest, FindCustomerResponse, Customer, int>
    {
        public FindCustomerUseCase(IResponseMapper responseMapper, IReadonlyRepository<Customer, int> repository) 
            : base(responseMapper, repository)
        {
        }
    }
}
