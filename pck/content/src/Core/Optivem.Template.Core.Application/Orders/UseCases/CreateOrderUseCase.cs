using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Common;
using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Application.Orders.Requests;
using Optivem.Template.Core.Application.Orders.Responses;
using Optivem.Template.Core.Domain.Customers;
using Optivem.Template.Core.Domain.Orders;
using Optivem.Template.Core.Domain.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Application.Orders.UseCases
{
    public class CreateOrderUseCase : RequestHandler<CreateOrderRequest, CreateOrderResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerReadRepository _customerReadRepository;
        private readonly IProductReadRepository _productReadRepository;

        public CreateOrderUseCase(IMapper mapper, IUnitOfWork unitOfWork, IOrderRepository orderRepository, ICustomerReadRepository customerReadRepository, IProductReadRepository productReadRepository)
            : base(mapper)
        {
            _unitOfWork = unitOfWork;
            _orderRepository = orderRepository;
            _customerReadRepository = customerReadRepository;
            _productReadRepository = productReadRepository;
        }

        public override async Task<CreateOrderResponse> HandleAsync(CreateOrderRequest request)
        {
            var order = await GetOrderAsync(request);

            order = await _orderRepository.AddAsync(order);
            await _unitOfWork.SaveChangesAsync();

            var response = Mapper.Map<Order, CreateOrderResponse>(order);
            return response;
        }

        private async Task<Order> GetOrderAsync(CreateOrderRequest request)
        {
            var customerId = new CustomerIdentity(request.CustomerId);

            var customer = await _customerReadRepository.FindAsync(customerId);

            if (customer == null)
            {
                throw new InvalidRequestException($"Customer {request.CustomerId} does not exist");
            }

            var orderDetails = new List<OrderItem>();

            for (int i = 0; i < request.OrderDetails.Count; i++)
            {
                var requestOrderDetail = request.OrderDetails[i];

                try
                {
                    var orderDetail = await GetOrderItem(requestOrderDetail);
                    orderDetails.Add(orderDetail);
                }
                catch (InvalidRequestException ex)
                {
                    var position = i + 1;
                    throw new InvalidRequestException($"Order detail at position {position} is invalid", ex);
                }
            }

            return OrderFactory.CreateNewOrder(customerId, orderDetails);
        }

        private async Task<OrderItem> GetOrderItem(CreateOrderRequest.OrderDetail requestOrderDetail)
        {
            var productId = new ProductIdentity(requestOrderDetail.ProductId);
            var product = await _productReadRepository.FindAsync(productId);

            if (product == null)
            {
                throw new InvalidRequestException($"Product id {requestOrderDetail.ProductId} is not valid because that product does not exist");
            }

            var quantity = requestOrderDetail.Quantity;

            return OrderFactory.CreateNewOrderDetail(product, quantity);
        }
    }
}