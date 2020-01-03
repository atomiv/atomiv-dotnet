using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Application.Mapping;
using Optivem.Template.Core.Domain.Customers;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Application.Customers.Commands
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerFactory _customerFactory;

        public CreateCustomerCommandHandler(IMapper mapper, ICustomerRepository customerRepository, ICustomerFactory customerFactory)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            _customerFactory = customerFactory;
        }

        public async Task<CreateCustomerCommandResponse> HandleAsync(CreateCustomerCommand request)
        {
            var customer = GetCustomer(request);

            await _customerRepository.AddAsync(customer);

            return _mapper.Map<Customer, CreateCustomerCommandResponse>(customer);
        }

        protected Customer GetCustomer(CreateCustomerCommand request)
        {
            var firstName = request.FirstName;
            var lastName = request.LastName;

            return _customerFactory.Create(firstName, lastName);
        }
    }
}