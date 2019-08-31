using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Domain;
using Optivem.Generator.Core.Application.Customers.Requests;
using Optivem.Generator.Core.Application.Customers.Responses;
using Optivem.Generator.Core.Domain.Customers.Entities;
using Optivem.Generator.Core.Domain.Customers.Repositories;
using Optivem.Generator.Core.Domain.Customers.ValueObjects;

namespace Optivem.Generator.Core.Application.Customers.UseCases
{
    public class DeleteCustomerUseCase : DeleteAggregateCase<ICustomerRepository, DeleteCustomerRequest, DeleteCustomerResponse, Customer, CustomerIdentity, int>
    {
        public DeleteCustomerUseCase(IUnitOfWork unitOfWork, IIdentityFactory<CustomerIdentity, int> identityFactory) 
            : base(unitOfWork, identityFactory)
        {
        }
    }
}
