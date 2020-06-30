using Atomiv.Core.Application;
using Atomiv.Template.Core.Application.Commands.Customers;
using Atomiv.Template.Core.Domain.Customers;
using System.Threading.Tasks;

namespace Atomiv.Template.Core.Application.Commands.Handlers.Customers
{
    public class EditCustomerCommandHandler : IRequestHandler<EditCustomerCommand, EditCustomerCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;

        public EditCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<EditCustomerCommandResponse> HandleAsync(EditCustomerCommand request)
        {
            var customerId = new CustomerIdentity(request.Id);

            var customer = await _customerRepository.FindAsync(customerId);

            if(customer == null)
            {
                throw new ValidationException($"Customer {customerId} does not exist");
            }

            UpdateCustomer(customer, request);

            await _customerRepository.UpdateAsync(customer);
            return _mapper.Map<Customer, EditCustomerCommandResponse>(customer);
        }

        private void UpdateCustomer(Customer customer, EditCustomerCommand request)
        {
            customer.FirstName = request.FirstName;
            customer.LastName = request.LastName;
        }
    }
}