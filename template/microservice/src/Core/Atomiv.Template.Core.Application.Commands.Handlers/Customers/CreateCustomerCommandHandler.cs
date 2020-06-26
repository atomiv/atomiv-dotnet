using Atomiv.Core.Application;
using Atomiv.Template.Core.Application.Commands.Customers;
using Atomiv.Template.Core.Application.Context;
using Atomiv.Template.Core.Common.Requests;
using Atomiv.Template.Core.Domain.Customers;
using System.Threading.Tasks;

namespace Atomiv.Template.Core.Application.Commands.Handlers.Customers
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerCommandResponse>
    {
        private readonly IApplicationUserContext _applicationUserContext;
        private readonly ICustomerFactory _customerFactory;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CreateCustomerCommandHandler(IApplicationUserContext applicationUserContext, ICustomerFactory customerFactory, ICustomerRepository customerRepository, IMapper mapper)
        {
            _applicationUserContext = applicationUserContext;
            _customerFactory = customerFactory;
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<CreateCustomerCommandResponse> HandleAsync(CreateCustomerCommand request)
        {
            var user = _applicationUserContext.ApplicationUser;

            var customer = CreateCustomer(request);

            await _customerRepository.AddAsync(customer);

            return _mapper.Map<Customer, CreateCustomerCommandResponse>(customer);
        }

        protected Customer CreateCustomer(CreateCustomerCommand request)
        {
            var firstName = request.FirstName;
            var lastName = request.LastName;

            return _customerFactory.CreateCustomer(firstName, lastName);
        }
    }
}