using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Common;
using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Application.Customers.Requests;
using Optivem.Template.Core.Application.Customers.Responses;
using Optivem.Template.Core.Domain.Customers;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Application.Customers.UseCases
{
    public class UpdateCustomerUseCase : RequestHandler<UpdateCustomerRequest, UpdateCustomerResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerRepository _customerRepository;

        public UpdateCustomerUseCase(IMapper mapper, IUnitOfWork unitOfWork, ICustomerRepository customerRepository)
            : base(mapper)
        {
            _unitOfWork = unitOfWork;
            _customerRepository = customerRepository;
        }

        public override async Task<UpdateCustomerResponse> HandleAsync(UpdateCustomerRequest request)
        {
            var customerId = new CustomerIdentity(request.Id);

            var customer = await _customerRepository.FindAsync(customerId);

            if (customer == null)
            {
                throw new NotFoundRequestException();
            }

            Update(customer, request);

            customer = await _customerRepository.UpdateAsync(customer);
            await _unitOfWork.SaveChangesAsync();
            return Mapper.Map<Customer, UpdateCustomerResponse>(customer);
        }

        private void Update(Customer customer, UpdateCustomerRequest request)
        {
            customer.FirstName = request.FirstName;
            customer.LastName = request.LastName;
        }
    }
}