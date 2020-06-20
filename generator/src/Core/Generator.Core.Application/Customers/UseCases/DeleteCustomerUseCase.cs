using Atomiv.Core.Application;
using Atomiv.Core.Application.Mappers;
using Atomiv.Core.Domain;
using Generator.Core.Application.Customers.Requests;
using Generator.Core.Application.Customers.Responses;
using Generator.Core.Domain.Customers;

namespace Generator.Core.Application.Customers.UseCases
{
    public class DeleteCustomerUseCase : DeleteAggregateCase<ICustomerRepository, DeleteCustomerRequest, DeleteCustomerResponse, Customer, CustomerIdentity, int>
    {
        public DeleteCustomerUseCase(IUseCaseMapper mapper, IUnitOfWork unitOfWork) 
            : base(mapper, unitOfWork)
        {
        }
    }
}
