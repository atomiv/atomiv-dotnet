using FluentAssertions;
using Atomiv.Template.Core.Domain.Products;
using Xunit;
using Atomiv.Infrastructure.System;
using System;

namespace Atomiv.Template.Core.Domain.UnitTest.Products
{
    public class ProductUnitTest
    {
        [Fact]
        public void CanConstructValidProduct()
        {
            var identity = new ProductIdentity(Guid.NewGuid());
            var code = "ABC";
            var name = "My name";
            decimal price = 10.50m;
            var isListed = true;

            var product = new Product(identity, code, name, price, isListed);

            product.Id.Should().Be(identity);
            product.ProductCode.Should().Be(code);
            product.ProductName.Should().Be(name);
            product.ListPrice.Should().Be(price);
            product.IsListed.Should().Be(isListed);
        }
    }
}