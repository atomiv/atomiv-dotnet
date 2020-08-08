using Atomiv.Core.Application;
using Atomiv.Core.Domain;
using Atomiv.Template.Core.Application.Commands.Orders;
using Atomiv.Template.Core.Application.Context;
using Atomiv.Template.Core.Domain.Customers;
using Atomiv.Template.Core.Domain.Orders;
using Atomiv.Template.Core.Domain.Products;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atomiv.Template.Core.Application.Commands.Handlers.Orders
{
    public class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand, CreateOrderCommandResponse>
    {
        private readonly IApplicationContext _applicationContext;
        private readonly IOrderFactory _orderFactory;
        private readonly IValidator<Order> _orderValidator; // TODO: VC: Consider also IValidator
        private readonly ICustomerReadonlyRepository _customerReadonlyRepository;
        private readonly IProductReadonlyRepository _productReadonlyRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(IApplicationContext applicationContext,
            IOrderFactory orderFactory,
            IValidator<Order> orderValidator,
            ICustomerReadonlyRepository customerReadonlyRepository,
            IProductReadonlyRepository productReadonlyRepository,
            IOrderRepository orderRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _applicationContext = applicationContext;
            _orderFactory = orderFactory;
            _orderValidator = orderValidator;
            _customerReadonlyRepository = customerReadonlyRepository;
            _productReadonlyRepository = productReadonlyRepository;
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CreateOrderCommandResponse> HandleAsync(CreateOrderCommand command)
        {
            var order = await CreateOrderAsync(command);

            var validationResult = await _orderValidator.ValidateAsync(order);

            if(!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            await _orderRepository.AddAsync(order);

            await _unitOfWork.CommitAsync();

            var response = _mapper.Map<Order, CreateOrderCommandResponse>(order);
            return response;
        }

        private async Task<Order> CreateOrderAsync(CreateOrderCommand command)
        {
            var customerId = new CustomerIdentity(command.CustomerId);

            var productIds = command.OrderItems
                .Select(e => new ProductIdentity(e.ProductId))
                .Distinct()
                .ToList();

            var products = await _productReadonlyRepository.FindReadonlyAsync(productIds);

            if (productIds.Count() != products.Count())
            {
                throw new ValidationException("Some products don't exist");
            }

            var orderItems = CreateOrderItems(command, products);
            var isPromotion = _applicationContext.IsPromotionDay;

            return _orderFactory.CreateOrder(customerId, orderItems);
        }

        private IEnumerable<OrderItem> CreateOrderItems(CreateOrderCommand command, IEnumerable<IReadonlyProduct> products)
        {
            var orderItems = new List<OrderItem>();

            foreach (var createOrderItemRequest in command.OrderItems)
            {
                var orderDetail = GetOrderItem(createOrderItemRequest, products);
                orderItems.Add(orderDetail);
            }

            return orderItems;
        }

        private OrderItem GetOrderItem(CreateOrderItemCommand command, IEnumerable<IReadonlyProduct> products)
        {
            var productId = new ProductIdentity(command.ProductId);

            var product = products.Single(e => e.Id == productId);

            var unitPrice = product.ListPrice;
            var quantity = command.Quantity;

            return _orderFactory.CreateOrderItem(productId, unitPrice, quantity);
        }
    }
}