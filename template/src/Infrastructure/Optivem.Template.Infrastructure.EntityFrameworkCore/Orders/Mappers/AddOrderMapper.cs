using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using Optivem.Template.Core.Domain.Orders;
using System.Linq;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Orders
{
    public class AddOrderMapper : IAddAggregateRootMapper<Order, OrderRecord>
    {
        public OrderRecord Create(Order aggregateRoot)
        {
            var id = aggregateRoot.Id.Id;
            var customerRecordId = aggregateRoot.CustomerId.Id;
            var orderStatusRecordId = (byte)aggregateRoot.Status;
            var orderDetailRecords = aggregateRoot.OrderDetails.Select(e => Create(e, id)).ToList();

            return new OrderRecord
            {
                Id = id,
                CustomerRecordId = customerRecordId,
                OrderStatusRecordId = orderStatusRecordId,
                OrderDetailRecords = orderDetailRecords,
            };
        }

        private OrderDetailRecord Create(OrderDetail orderDetail, int orderRecordId)
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
    }
}