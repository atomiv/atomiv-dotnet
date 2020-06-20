using System.Threading.Tasks;
using Atomiv.Core.Application;
using Atomiv.Template.Core.Application.Commands.Customers;
using Atomiv.Template.Core.Domain.Customers;

namespace Atomiv.Template.Core.Application.Commands.Handlers.Customers
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, DeleteCustomerCommandResponse>
    {
        private readonly ICustomerRepository _customerRepository;

        public DeleteCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<DeleteCustomerCommandResponse> HandleAsync(DeleteCustomerCommand request)
        {
            var customerId = new CustomerIdentity(request.Id);

            await _customerRepository.RemoveAsync(customerId);

            return new DeleteCustomerCommandResponse();
        }
    }
}