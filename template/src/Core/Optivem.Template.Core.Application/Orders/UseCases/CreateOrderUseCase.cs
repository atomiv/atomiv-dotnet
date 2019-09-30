using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Application.Orders.Requests;
using Optivem.Template.Core.Application.Orders.Responses;
using Optivem.Template.Core.Domain.Customers;
using Optivem.Template.Core.Domain.Orders;
using Optivem.Template.Core.Domain.Products;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Application.Orders.UseCases
{
    public class CreateOrderUseCase : CreateAggregateUseCase<IOrderRepository, CreateOrderRequest, CreateOrderResponse, Order, OrderIdentity, int>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;

        public CreateOrderUseCase(IMapper mapper, IUnitOfWork unitOfWork, ICustomerRepository customerRepository, IProductRepository productRepository) 
            : base(mapper, unitOfWork)
        {
            _customerRepository = customerRepository;
            _productRepository = productRepository;
        }

        protected override async Task<Order> CreateAggregateRootAsync(CreateOrderRequest request)
        {
            var customerId = new CustomerIdentity(request.CustomerId);

            var customer = await _customerRepository.GetAsync(customerId);

            if(customer == null)
            {
                throw new InvalidRequestException($"Customer {request.CustomerId} does not exist");
            }

            var orderDetails = new List<OrderDetail>();

            for(int i = 0; i < request.OrderDetails.Count; i++)
            {
                var requestOrderDetail = request.OrderDetails[i];

                try
                {
                    var orderDetail = await CreateAsync(requestOrderDetail);
                    orderDetails.Add(orderDetail);
                }
                catch(InvalidRequestException ex)
                {
                    var position = i + 1;
                    throw new InvalidRequestException($"Order detail at position {position} is invalid", ex);
                }
            }

            return OrderFactory.CreateNewOrder(customerId, orderDetails);
        }

        private async Task<OrderDetail> CreateAsync(CreateOrderRequest.OrderDetail requestOrderDetail)
        {
            var productId = new ProductIdentity(requestOrderDetail.ProductId);
            var product = await _productRepository.GetAsync(productId);

            if(product == null)
            {
                throw new InvalidRequestException($"Product id {requestOrderDetail.ProductId} is not valid because that product does not exist");
            }

            var quantity = requestOrderDetail.Quantity;

            return OrderFactory.CreateNewOrderDetail(product, quantity);
        }
    }
}
