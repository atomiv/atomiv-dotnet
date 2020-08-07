using System.Threading.Tasks;
using Atomiv.Core.Application;
using Atomiv.Template.Core.Application.Commands.Customers;
using Atomiv.Template.Core.Domain.Customers;

namespace Atomiv.Template.Core.Application.Commands.Handlers.Customers
{
    public class DeleteCustomerCommandHandler : ICommandHandler<DeleteCustomerCommand, DeleteCustomerCommandResponse>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCustomerCommandHandler(ICustomerRepository customerRepository,
            IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<DeleteCustomerCommandResponse> HandleAsync(DeleteCustomerCommand command)
        {
            var customerId = new CustomerIdentity(command.Id);

            var exists = await _customerRepository.ExistsAsync(customerId);
            
            if(!exists)
            {
                throw new ExistenceException($"Customer {customerId} does not exist");
            }

            await _customerRepository.RemoveAsync(customerId);

            await _unitOfWork.CommitAsync();

            return new DeleteCustomerCommandResponse();
        }
    }
}