using Optivem.Template.Core.Domain.Customers;
using Optivem.Template.Core.Domain.Orders;
using Optivem.Template.Core.Domain.Products;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Template.Infrastructure.Persistence.IntegrationTest
{
    public class Test : IClassFixture<Fixture>
    {
        protected readonly ICustomerFactory _customerFactory;
        protected readonly IOrderFactory _orderFactory;
        protected readonly IProductFactory _productFactory;

        protected readonly ICustomerRepository _customerRepository;
        protected readonly IOrderRepository _orderRepository;
        protected readonly IProductRepository _productRepository;


        public Test(Fixture fixture)
        {
            Fixture = fixture;

            _customerFactory = Fixture.GetService<ICustomerFactory>();
            _orderFactory = Fixture.GetService<IOrderFactory>();
            _productFactory = Fixture.GetService<IProductFactory>();

            _customerRepository = Fixture.GetService<ICustomerRepository>();
            _orderRepository = Fixture.GetService<IOrderRepository>();
            _productRepository = Fixture.GetService<IProductRepository>();
        }

        public Fixture Fixture { get; }

        protected async Task<List<Customer>> CreateSomeCustomersAsync()
        {
            var customers = new List<Customer>();

            for (var i = 0; i < 10; i++)
            {
                var customer = _customerFactory.Create($"John{i}", $"Smith{i}");
                await _customerRepository.AddAsync(customer);
                customers.Add(customer);
            }

            return customers;
        }

        protected async Task<List<Product>> CreateSomeProductsAsync()
        {
            var products = new List<Product>();

            for (var i = 0; i < 10; i++)
            {
                var product = _productFactory.CreateNewProduct($"PRD{i}", $"Product {i}", 50 + i);
                await _productRepository.AddAsync(product);
                products.Add(product);
            }

            return products;
        }

        protected async Task<List<Order>> CreateSomeOrdersAsync(List<Customer> customers, List<Product> products)
        {
            var customerId = customers[1].Id;
            var productId1 = products[1].Id;
            var productId2 = products[2].Id;

            var orders = new List<Order>();

            for (var i = 0; i < 10; i++)
            {
                var orderItem1 = _orderFactory.CreateNewOrderItem(productId1, 56.92m, 40);
                var orderItem2 = _orderFactory.CreateNewOrderItem(productId2, 72.46m, 50);

                var orderItems = new List<OrderItem>
                {
                    orderItem1,
                    orderItem2,
                };

                var order = _orderFactory.CreateNewOrder(customerId, orderItems);

                await _orderRepository.AddAsync(order);
            }

            return orders;
        }
    }
}
