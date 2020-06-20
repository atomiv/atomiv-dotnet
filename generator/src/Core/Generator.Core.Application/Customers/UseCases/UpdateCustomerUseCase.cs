using Atomiv.Core.Application;
using Atomiv.Core.Application.Mappers;
using Atomiv.Core.Domain;
using Generator.Core.Application.Customers.Requests;
using Generator.Core.Application.Customers.Responses;
using Generator.Core.Domain.Customers;

namespace Generator.Core.Application.Customers.UseCases
{
    public class UpdateCustomerUseCase : UpdateAggregateUseCase<ICustomerRepository, UpdateCustomerRequest, UpdateCustomerResponse, Customer, CustomerIdentity, int>
    {
        public UpdateCustomerUseCase(IUseCaseMapper mapper, IUnitOfWork unitOfWork) 
            : base(mapper, unitOfWork)
        {
        }

        protected override void Update(Customer aggregateRoot, UpdateCustomerRequest request)
        {
            aggregateRoot.FirstName = request.FirstName;
            aggregateRoot.LastName = request.LastName;
        }
    }
}
