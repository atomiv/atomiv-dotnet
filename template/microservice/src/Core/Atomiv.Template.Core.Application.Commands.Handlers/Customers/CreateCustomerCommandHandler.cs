using Atomiv.Core.Application;
using Atomiv.Template.Core.Application.Commands.Customers;
using Atomiv.Template.Core.Application.Context;
using Atomiv.Template.Core.Domain.Customers;
using System.Threading.Tasks;

namespace Atomiv.Template.Core.Application.Commands.Handlers.Customers
{
    public class CreateCustomerCommandHandler : ICommandHandler<CreateCustomerCommand, CreateCustomerCommandResponse>
    {
        private readonly IApplicationUserContext _applicationUserContext;
        private readonly ICustomerFactory _customerFactory;
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEventBus _eventBus;
        private readonly IMapper _mapper;

        public CreateCustomerCommandHandler(IApplicationUserContext applicationUserContext, 
            ICustomerFactory customerFactory, 
            ICustomerRepository customerRepository, 
            IUnitOfWork unitOfWork,
            IEventBus eventBus,
            IMapper mapper)
        {
            _applicationUserContext = applicationUserContext;
            _customerFactory = customerFactory;
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
            _eventBus = eventBus;
            _mapper = mapper;
        }

        public async Task<CreateCustomerCommandResponse> HandleAsync(CreateCustomerCommand command)
        {
            var customer = CreateCustomer(command);

            await _customerRepository.AddAsync(customer);

            await _unitOfWork.CommitAsync();

            // TODO: VC: Refactor
            var customerCreatedEvent = new CustomerCreatedEvent(customer.Id, customer.ReferenceNumber, customer.FirstName, customer.LastName);

            await _eventBus.PublishAsync(customerCreatedEvent);

            return _mapper.Map<Customer, CreateCustomerCommandResponse>(customer);
        }

        protected Customer CreateCustomer(CreateCustomerCommand command)
        {
            // TODO: VC: Move to validator
            if (string.IsNullOrEmpty(command.FirstName))
            {
                throw new ValidationException("First name can't be empty!!!");
            }

            var user = _applicationUserContext.ApplicationUser;

            var firstName = command.FirstName;
            var lastName = command.LastName;

            return _customerFactory.CreateCustomer(firstName, lastName);
        }
    }
}