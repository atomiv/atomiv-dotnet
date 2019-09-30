using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Application.Customers.Requests;
using Optivem.Template.Core.Application.Customers.Responses;
using Optivem.Template.Core.Domain.Customers;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Application.Customers.UseCases
{
    public class CreateCustomerUseCase : CreateAggregateUseCase<ICustomerRepository, CreateCustomerRequest, CreateCustomerResponse, Customer, CustomerIdentity, int>
    {
        public CreateCustomerUseCase(IMapper mapper, IUnitOfWork unitOfWork) 
            : base(mapper, unitOfWork)
        {
        }

        protected override Task<Customer> CreateAggregateRootAsync(CreateCustomerRequest request)
        {
            var customer = new Customer(CustomerIdentity.Null,
                                request.FirstName,
                                request.LastName);

            return Task.FromResult(customer);
        }
    }
}