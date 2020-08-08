using Atomiv.Core.Application;
using Atomiv.Core.Domain;
using Atomiv.Template.Core.Application.Commands.Orders;
using Atomiv.Template.Core.Domain.Orders;
using System.Threading.Tasks;

namespace Atomiv.Template.Core.Application.Commands.Handlers.Orders
{
    public class CancelOrderCommandHandler : ICommandHandler<CancelOrderCommand, CancelOrderCommandResponse>
    {
        private readonly IValidator<Order> _orderValidator;
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CancelOrderCommandHandler(IValidator<Order> orderValidator,
            IOrderRepository orderRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _orderValidator = orderValidator;
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CancelOrderCommandResponse> HandleAsync(CancelOrderCommand command)
        {
            var orderId = new OrderIdentity(command.Id);

            var order = await _orderRepository.FindAsync(orderId);

            if(order == null)
            {
                throw new ExistenceException();
            }

            order.Cancel();

            var validationResult = await _orderValidator.ValidateAsync(order);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            await _orderRepository.UpdateAsync(order);

            await _unitOfWork.CommitAsync();

            return _mapper.Map<Order, CancelOrderCommandResponse>(order);
        }
    }
}