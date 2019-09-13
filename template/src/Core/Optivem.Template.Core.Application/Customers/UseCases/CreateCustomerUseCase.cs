using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Application.Customers.Requests;
using Optivem.Template.Core.Application.Customers.Responses;
using Optivem.Template.Core.Domain.Customers;

namespace Optivem.Template.Core.Application.Customers.UseCases
{
    public class CreateCustomerUseCase : CreateAggregateUseCase<ICustomerRepository, CreateCustomerRequest, CreateCustomerResponse, Customer, CustomerIdentity, int>
    {
        public CreateCustomerUseCase(IMapper mapper, IUnitOfWork unitOfWork) 
            : base(mapper, unitOfWork)
        {
        }

        protected override Customer CreateAggregateRoot(Customer aggregateRoot, CustomerIdentity identity)
        {
            return new Customer(identity, aggregateRoot.FirstName, aggregateRoot.LastName);
        }
    }
}