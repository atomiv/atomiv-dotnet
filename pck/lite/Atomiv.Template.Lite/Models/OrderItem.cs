using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atomiv.Template.Lite.Models
{
    public class OrderItem
    {
        // [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        // (ProductCode, PoductDescription, ProductPrice)
        public string ProductCode { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        // --- TODO product info should be inferred
        public short Quantity { get; set; }


        // public Order order { get; set; }
        // public ItemDetails[] itemDetails { get; set; }

    }
}
