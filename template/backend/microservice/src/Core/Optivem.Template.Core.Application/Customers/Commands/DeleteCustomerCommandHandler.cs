using System.Threading.Tasks;
using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Domain.Customers;

namespace Optivem.Template.Core.Application.Customers.Commands
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, DeleteCustomerCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerRepository _customerRepository;

        public DeleteCustomerCommandHandler(IUnitOfWork unitOfWork, ICustomerRepository customerRepository)
        {
            _unitOfWork = unitOfWork;
            _customerRepository = customerRepository;
        }

        public async Task<DeleteCustomerCommandResponse> HandleAsync(DeleteCustomerCommand request)
        {
            var customerId = new CustomerIdentity(request.Id);

            var exists = await _customerRepository.ExistsAsync(customerId);

            if (!exists)
            {
                throw new NotFoundRequestException();
            }

            _customerRepository.Remove(customerId);

            await _unitOfWork.SaveChangesAsync();

            return new DeleteCustomerCommandResponse();
        }
    }
}