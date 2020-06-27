using Atomiv.Infrastructure.MongoDb;
using Atomiv.Template.Core.Common.Orders;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atomiv.Template.Infrastructure.Domain.Persistence.MongoDb.Records
{
    public class OrderItemRecord : Record<ObjectId>
    {
        public ObjectId ProductId { get; set; }

        public OrderItemStatus StatusId { get; set; }

        public decimal Quantity { get; set; }

        public decimal UnitPrice { get; set; }
    }
}
