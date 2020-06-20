using Atomiv.Core.Application;
using Atomiv.Core.Application.Mappers;
using Atomiv.Core.Domain;
using Generator.Core.Application.Customers.Requests;
using Generator.Core.Application.Customers.Responses;
using Generator.Core.Domain.Customers;

namespace Generator.Core.Application.Customers.UseCases
{
    public class CreateCustomerUseCase : CreateAggregateUseCase<ICustomerRepository, CreateCustomerRequest, CreateCustomerResponse, Customer, CustomerIdentity, int>
    {
        public CreateCustomerUseCase(IUseCaseMapper mapper, IUnitOfWork unitOfWork) 
            : base(mapper, unitOfWork)
        {
        }

        protected override Customer CreateAggregateRoot(Customer aggregateRoot, CustomerIdentity identity)
        {
            return new Customer(identity, aggregateRoot.FirstName, aggregateRoot.LastName);
        }

        protected override Customer CreateAggregateRoot(CreateCustomerRequest request)
        {
            return new Customer(CustomerIdentity.Null, request.FirstName, request.LastName);
        }
    }
}