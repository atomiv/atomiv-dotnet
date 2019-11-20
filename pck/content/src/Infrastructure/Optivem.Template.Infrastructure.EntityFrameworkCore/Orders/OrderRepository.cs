using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Domain.Orders;
using System.Threading.Tasks;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Orders
{
    public class OrderRepository : OrderReadRepository, IOrderRepository
    {
        public OrderRepository(DatabaseContext context) : base(context)
        {
        }

        public Task<Order> AddAsync(Order order)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveAsync(OrderIdentity orderId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Order> UpdateAsync(Order order)
        {
            throw new System.NotImplementedException();
        }

        /*
         * 
        public OrderRecord Map(Order aggregateRoot)
        {
            var id = aggregateRoot.Id.Id;
            var customerRecordId = aggregateRoot.CustomerId.Id;
            var orderStatusRecordId = (byte)aggregateRoot.Status;
            var orderDetailRecords = aggregateRoot.OrderItems.Select(e => Create(e, id)).ToList();

            return new OrderRecord
            {
                Id = id,
                CustomerRecordId = customerRecordId,
                OrderStatusRecordId = orderStatusRecordId,
                OrderDetailRecords = orderDetailRecords,
            };
        }

        private OrderDetailRecord Create(OrderItem orderDetail, int orderRecordId)
        {
            var id = orderDetail.Id.Id;
            var productRecordId = orderDetail.ProductId.Id;
            var orderDetailStatusRecordId = (byte)orderDetail.Status;
            var quantity = orderDetail.Quantity;
            var unitPrice = orderDetail.UnitPrice;

            return new OrderDetailRecord
            {
                Id = id,
                OrderRecordId = orderRecordId,
                ProductRecordId = productRecordId,
                OrderDetailStatusRecordId = orderDetailStatusRecordId,
                Quantity = quantity,
                UnitPrice = unitPrice,
            };
        }
         * 
         * 
         *
         *
         * 
        public Order Map(OrderRecord record)
        {
            var id = new OrderIdentity(record.Id);
            var customerId = new CustomerIdentity(record.CustomerRecordId);
            OrderStatus status = (OrderStatus)record.OrderStatusRecordId; // TODO: VC
            var orderDetails = record.OrderDetailRecords.Select(Create).ToList().AsReadOnly();

            // TODO: VC: OrderDetails is empty list, need to Include it in EF so that it loads...

            return new Order(id, customerId, DateTime.Now, status, orderDetails);
        }

        private static OrderItem Create(OrderDetailRecord record)
        {
            var id = new OrderItemIdentity(record.Id);
            var productId = new ProductIdentity(record.ProductRecordId);
            var quantity = record.Quantity;
            var unitPrice = record.UnitPrice;
            var status = (OrderItemStatus)record.OrderDetailStatusRecordId; // TODO: VC

            return new OrderItem(id, productId, quantity, unitPrice, status);
        }

        public List<Expression<Func<OrderRecord, object>>> GetIncludes()
        {
            return new List<Expression<Func<OrderRecord, object>>>
            {
                e => e.OrderDetailRecords
            };
        }



        public OrderRecord Map(Order aggregateRoot, OrderRecord record)
        {
            record.CustomerRecordId = aggregateRoot.CustomerId.Id;
            record.OrderStatusRecordId = (byte)aggregateRoot.Status;

            var addedOrderDetails = aggregateRoot.OrderItems
                .Where(e => e.Id == OrderItemIdentity.New);

            var addedOrderDetailRecords = addedOrderDetails
                .Select(e => CreateOrderDetailRecord(e))
                .ToList();

            var removedOrderDetailRecords = record.OrderDetailRecords
                .Where(e => !aggregateRoot.OrderItems.Any(f => f.Id.Id == e.Id))
                .ToList();

            var updatedOrderDetailRecords = record.OrderDetailRecords
                .Where(e => aggregateRoot.OrderItems.Any(f => f.Id.Id == e.Id))
                .ToList();

            foreach(var addedOrderDetailRecord in addedOrderDetailRecords)
            {
                record.OrderDetailRecords.Add(addedOrderDetailRecord);
            }

            foreach(var removedOrderDetailRecord in removedOrderDetailRecords)
            {
                record.OrderDetailRecords.Remove(removedOrderDetailRecord);
            }

            foreach(var updatedOrderDetailRecord in updatedOrderDetailRecords)
            {
                var orderDetail = aggregateRoot.OrderItems.Single(e => e.Id.Id == updatedOrderDetailRecord.Id);

                UpdateOrderDetailRecord(orderDetail, updatedOrderDetailRecord);
            }

            return record;
        }

        private OrderDetailRecord CreateOrderDetailRecord(OrderItem orderDetail)
        {
            var productRecordId = orderDetail.ProductId.Id;
            var orderDetailStatusRecordId = (byte)orderDetail.Status;
            var quantity = orderDetail.Quantity;
            var unitPrice = orderDetail.UnitPrice;

            return new OrderDetailRecord
            {
                ProductRecordId = productRecordId,
                OrderDetailStatusRecordId = orderDetailStatusRecordId,
                Quantity = quantity,
                UnitPrice = unitPrice,
            };
        }

        private void UpdateOrderDetailRecord(OrderItem orderDetail, OrderDetailRecord orderDetailRecord)
        {
            var productRecordId = orderDetail.ProductId.Id;
            var orderDetailStatusRecordId = (byte)orderDetail.Status;
            var quantity = orderDetail.Quantity;
            var unitPrice = orderDetail.UnitPrice;

            orderDetailRecord.ProductRecordId = productRecordId;
            orderDetailRecord.OrderDetailStatusRecordId = orderDetailStatusRecordId;
            orderDetailRecord.Quantity = quantity;
            orderDetailRecord.UnitPrice = unitPrice;
        }
    }

         * 
         * 
         */
    }
}