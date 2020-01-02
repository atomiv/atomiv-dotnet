using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Application.Mapping;
using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Domain.Customers;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Application.Customers.Commands
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerFactory _customerFactory;

        public CreateCustomerCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, ICustomerRepository customerRepository, ICustomerFactory customerFactory)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _customerRepository = customerRepository;
            _customerFactory = customerFactory;
        }

        public async Task<CreateCustomerCommandResponse> HandleAsync(CreateCustomerCommand request)
        {
            var customer = GetCustomer(request);

            _customerRepository.Add(customer);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<Customer, CreateCustomerCommandResponse>(customer);
        }

        protected Customer GetCustomer(CreateCustomerCommand request)
        {
            var firstName = request.FirstName;
            var lastName = request.LastName;

            return _customerFactory.Create(firstName, lastName);
        }

        /*
         * 
        public override async Task<TResponse> HandleAsync(TRequest request)
        {
            var aggregateRoot = await CreateAggregateRootAsync(request);

            var repository = GetRepository();
            aggregateRoot = await repository.AddAsync(aggregateRoot);
            await UnitOfWork.SaveChangesAsync();

            var response = Mapper.Map<TAggregateRoot, TResponse>(aggregateRoot);
            return response;
        }
         * 
         */
    }
}