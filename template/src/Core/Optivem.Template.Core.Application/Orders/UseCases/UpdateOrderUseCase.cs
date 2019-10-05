using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Application.Orders.Requests;
using Optivem.Template.Core.Application.Orders.Responses;
using Optivem.Template.Core.Domain.Customers;
using Optivem.Template.Core.Domain.Orders;
using Optivem.Template.Core.Domain.Products;
using System.Linq;
using System.Threading.Tasks;

namespace Optivem.Template.Core.Application.Orders.UseCases
{
    public class UpdateOrderUseCase : UpdateAggregateUseCase<IOrderRepository, UpdateOrderRequest, UpdateOrderResponse, Order, OrderIdentity, int>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;

        public UpdateOrderUseCase(IMapper mapper, IUnitOfWork unitOfWork, ICustomerRepository customerRepository, IProductRepository productRepository) 
            : base(mapper, unitOfWork)
        {
            _customerRepository = customerRepository;
            _productRepository = productRepository;
        }

        protected override async Task UpdateAsync(UpdateOrderRequest request, Order aggregateRoot)
        {
            var customerId = new CustomerIdentity(request.CustomerId);
            var existsCustomer = await _customerRepository.ExistsAsync(customerId);

            if(!existsCustomer)
            {
                throw new InvalidRequestException($"Customer {request.CustomerId} does not exist");
            }

            aggregateRoot.CustomerId = customerId;

            var currentOrderDetails = aggregateRoot.OrderDetails;

            var addedOrderRequestDetails = request.OrderDetails.Where(e => e.Id == null).ToList();
            var updatedOrderRequestDetails = request.OrderDetails.Where(e => e.Id != null).ToList();
            var deletedOrderDetails = aggregateRoot.OrderDetails.Where(e => !request.OrderDetails.Any(f => f.Id == e.Id.Id)).ToList();

            foreach(var added in addedOrderRequestDetails)
            {
                var productId = new ProductIdentity(added.ProductId);
                var product = await _productRepository.FindAsync(productId);

                if(product == null)
                {
                    throw new InvalidRequestException($"Product {productId} does not exist");
                }

                var orderDetail = OrderFactory.CreateNewOrderDetail(product, added.Quantity);
                aggregateRoot.AddOrderDetail(orderDetail);
            }

            foreach(var updated in updatedOrderRequestDetails)
            {
                var orderDetailId = new OrderDetailIdentity(updated.Id.Value);
                var orderDetail = aggregateRoot.OrderDetails.First(e => e.Id == orderDetailId);

                var productId = new ProductIdentity(updated.ProductId);
                var product = await _productRepository.FindAsync(productId);

                if (product == null)
                {
                    throw new InvalidRequestException($"Product {productId} does not exist");
                }

                orderDetail.SetProduct(product);
                orderDetail.Quantity = updated.Quantity;
            }

            foreach(var deleted in deletedOrderDetails)
            {
                aggregateRoot.RemoveOrderDetail(deleted.Id);
            }
        }
    }
}
