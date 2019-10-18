using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using Optivem.Template.Infrastructure.EntityFrameworkCore.Products;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Orders
{
    public class OrderDetailRecord : Record<int>
    {
        public int OrderRecordId { get; set; }
        public int ProductRecordId { get; set; }
        public byte OrderDetailStatusRecordId { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public virtual OrderRecord OrderRecord { get; set; }
        public virtual ProductRecord ProductRecord { get; set; }
        public virtual OrderDetailStatusRecord OrderDetailStatusRecord { get; set; }
    }
}