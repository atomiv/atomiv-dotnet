using Optivem.Core.Application;
using Optivem.Core.Domain;
using Optivem.NorthwindLite.Core.Application.Interface.Customers.Commands;
using Optivem.NorthwindLite.Core.Application.Interface.Requests.Customers;
using Optivem.NorthwindLite.Core.Domain.Entities;

namespace Optivem.NorthwindLite.Core.Application.UseCases
{
    public class CreateCustomerUseCase : CreateUseCase<CreateCustomerRequest, CreateCustomerResponse, Customer, int>
    {
        public CreateCustomerUseCase(IRequestMapper requestMapper, IResponseMapper responseMapper, IUnitOfWork unitOfWork, ICrudRepository<Customer, int> repository)
            : base(requestMapper, responseMapper, unitOfWork, repository)
        {
        }
    }
}