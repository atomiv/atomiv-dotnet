using System.Threading.Tasks;
using Optivem.Framework.Core.Application;
using Optivem.Template.Core.Application.Customers.Repositories;
using Optivem.Template.Core.Domain.Customers;

namespace Optivem.Template.Core.Application.Customers.Commands
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, DeleteCustomerCommandResponse>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerReadRepository _customerReadRepository;

        // TODO: VC: Add just like there is RequestValidator, also ExistenceValidator or see if response code of validator can be customized?

        public DeleteCustomerCommandHandler(ICustomerRepository customerRepository, ICustomerReadRepository customerReadRepository)
        {
            _customerRepository = customerRepository;
            _customerReadRepository = customerReadRepository;
        }

        public async Task<DeleteCustomerCommandResponse> HandleAsync(DeleteCustomerCommand request)
        {
            var customerId = new CustomerIdentity(request.Id);

            await _customerRepository.RemoveAsync(customerId);

            return new DeleteCustomerCommandResponse();
        }
    }
}