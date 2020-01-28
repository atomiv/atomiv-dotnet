using Optivem.Atomiv.Core.Application;
using Optivem.Atomiv.Core.Application.Mapping;
using Optivem.Atomiv.Template.Core.Domain.Customers;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Template.Core.Application.Customers.Commands
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, UpdateCustomerCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;

        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<UpdateCustomerCommandResponse> HandleAsync(UpdateCustomerCommand request)
        {
            var customerId = new CustomerIdentity(request.Id);

            var customer = await _customerRepository.FindAsync(customerId);

            UpdateCustomer(customer, request);

            await _customerRepository.UpdateAsync(customer);
            return _mapper.Map<Customer, UpdateCustomerCommandResponse>(customer);
        }

        private void UpdateCustomer(Customer customer, UpdateCustomerCommand request)
        {
            customer.FirstName = request.FirstName;
            customer.LastName = request.LastName;
        }
    }
}