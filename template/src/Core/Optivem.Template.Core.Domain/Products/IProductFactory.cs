using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Core.Domain.Products
{
    public interface IProductFactory
    {
        Product CreateNewProduct(string productCode, string productName, decimal listPrice);
    }
}
