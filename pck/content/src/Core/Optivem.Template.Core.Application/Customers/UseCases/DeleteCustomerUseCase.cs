using System.Threading.Tasks;
using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Common;
using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Application.Customers.Requests;
using Optivem.Template.Core.Application.Customers.Responses;
using Optivem.Template.Core.Domain.Customers;

namespace Optivem.Template.Core.Application.Customers.UseCases
{
    public class DeleteCustomerUseCase : RequestHandler<DeleteCustomerRequest, DeleteCustomerResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerRepository _customerRepository;

        public DeleteCustomerUseCase(IMapper mapper, IUnitOfWork unitOfWork, ICustomerRepository customerRepository)
            : base(mapper)
        {
            _unitOfWork = unitOfWork;
            _customerRepository = customerRepository;
        }

        public override async Task<DeleteCustomerResponse> HandleAsync(DeleteCustomerRequest request)
        {
            var customerId = new CustomerIdentity(request.Id);

            var exists = await _customerRepository.ExistsAsync(customerId);

            if (!exists)
            {
                throw new NotFoundRequestException();
            }

            _customerRepository.Remove(customerId);

            await _unitOfWork.SaveChangesAsync();

            return new DeleteCustomerResponse();
        }
    }
}