using Atomiv.Infrastructure.MongoDB;
using System;

namespace Atomiv.Template.Infrastructure.Domain.Persistence.MongoDB.Records
{
    public class ProductRecord : Record<Guid>
    {
        public string ProductCode { get; set; }

        public string ProductName { get; set; }

        public decimal ListPrice { get; set; }

        public bool IsListed { get; set; }
    }
}
