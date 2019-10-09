using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using Optivem.Template.Core.Domain.Customers;
using Optivem.Template.Core.Domain.Orders;
using Optivem.Template.Core.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Orders
{
    public class OrderFactory : IAggregateRootFactory<Order, OrderRecord>
    {
        public Order Create(OrderRecord record)
        {
            var id = new OrderIdentity(record.Id);
            var customerId = new CustomerIdentity(record.CustomerRecordId);
            OrderStatus status = (OrderStatus)record.OrderStatusRecordId; // TODO: VC
            var orderDetails = record.OrderDetailRecords.Select(Create).ToList().AsReadOnly();

            // TODO: VC: OrderDetails is empty list, need to Include it in EF so that it loads...

            return new Order(id, customerId, status, orderDetails);
        }

        private static OrderDetail Create(OrderDetailRecord record)
        {
            var id = new OrderDetailIdentity(record.Id);
            var productId = new ProductIdentity(record.ProductRecordId);
            var quantity = record.Quantity;
            var unitPrice = record.UnitPrice;
            var status = (OrderDetailStatus)record.StatusRecordId; // TODO: VC

            return new OrderDetail(id, productId, quantity, unitPrice, status);
        }
    }
}
