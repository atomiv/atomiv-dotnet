using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Application.Mapping;
using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Domain.Customers;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Application.Customers.Commands
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, UpdateCustomerCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerRepository _customerRepository;

        public UpdateCustomerCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _customerRepository = customerRepository;
        }

        public async Task<UpdateCustomerCommandResponse> HandleAsync(UpdateCustomerCommand request)
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
            return _mapper.Map<Customer, UpdateCustomerCommandResponse>(customer);
        }

        private void Update(Customer customer, UpdateCustomerCommand request)
        {
            customer.FirstName = request.FirstName;
            customer.LastName = request.LastName;
        }
    }
}