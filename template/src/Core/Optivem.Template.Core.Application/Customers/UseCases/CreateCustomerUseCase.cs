using Optivem.Framework.Core.Common;
using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Application.Customers.Requests;
using Optivem.Template.Core.Application.Customers.Responses;
using Optivem.Template.Core.Domain.Customers;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Application.Customers.UseCases
{
    public class CreateCustomerUseCase : IRequestHandler<CreateCustomerRequest, CreateCustomerResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerRepository _customerRepository;

        public CreateCustomerUseCase(IMapper mapper, IUnitOfWork unitOfWork, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _customerRepository = customerRepository;
        }

        public async Task<CreateCustomerResponse> HandleAsync(CreateCustomerRequest request)
        {
            var customer = GetCustomer(request);

            _customerRepository.Add(customer);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<Customer, CreateCustomerResponse>(customer);
        }

        protected Customer GetCustomer(CreateCustomerRequest request)
        {
            var id = CustomerIdentity.New();
            var firstName = request.FirstName;
            var lastName = request.LastName;

            return new Customer(id, firstName, lastName);
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