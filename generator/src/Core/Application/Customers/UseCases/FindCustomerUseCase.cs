using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Application.Mappers;
using Optivem.Framework.Core.Domain;
using Optivem.Generator.Core.Application.Customers.Requests;
using Optivem.Generator.Core.Application.Customers.Responses;
using Optivem.Generator.Core.Domain.Customers;

namespace Optivem.Generator.Core.Application.Customers.UseCases
{
    public class FindCustomerUseCase : FindAggregateUseCase<ICustomerRepository, FindCustomerRequest, FindCustomerResponse, Customer, CustomerIdentity, int>
    {
        public FindCustomerUseCase(IUseCaseMapper mapper, IUnitOfWork unitOfWork) 
            : base(mapper, unitOfWork)
        {
        }
    }
}