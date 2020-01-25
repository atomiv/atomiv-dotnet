using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Application.Mapping;
using Optivem.Template.Core.Domain.Customers;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Application.Customers.Commands
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerCommandResponse>
    {
        private readonly ICustomerFactory _customerFactory;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CreateCustomerCommandHandler(ICustomerFactory customerFactory, ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerFactory = customerFactory;
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<CreateCustomerCommandResponse> HandleAsync(CreateCustomerCommand request)
        {
            var customer = CreateCustomer(request);

            await _customerRepository.AddAsync(customer);

            return _mapper.Map<Customer, CreateCustomerCommandResponse>(customer);
        }

        protected Customer CreateCustomer(CreateCustomerCommand request)
        {
            var firstName = request.FirstName;
            var lastName = request.LastName;

            return _customerFactory.Create(firstName, lastName);
        }
    }
}