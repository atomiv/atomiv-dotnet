using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Application.Mapping;
using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Application.Customers.Requests;
using Optivem.Template.Core.Application.Customers.Responses;
using Optivem.Template.Core.Domain.Customers;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Application.Customers.UseCases
{
    public class UpdateCustomerUseCase : IRequestHandler<UpdateCustomerRequest, CustomerResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerRepository _customerRepository;

        public UpdateCustomerUseCase(IMapper mapper, IUnitOfWork unitOfWork, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _customerRepository = customerRepository;
        }

        public async Task<CustomerResponse> HandleAsync(UpdateCustomerRequest request)
        {
            var customerId = new CustomerIdentity(request.Id);

            var customer = await _customerRepository.FindAsync(customerId);

            if (customer == null)
            {
                throw new NotFoundRequestException();
            }

            Update(customer, request);

            await _customerRepository.UpdateAsync(customer);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<Customer, CustomerResponse>(customer);
        }

        private void Update(Customer customer, UpdateCustomerRequest request)
        {
            customer.FirstName = request.FirstName;
            customer.LastName = request.LastName;
        }
    }
}