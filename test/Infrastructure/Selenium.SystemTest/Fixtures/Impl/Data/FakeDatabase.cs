using Optivem.Framework.Infrastructure.Selenium.SystemTest.Fixtures.Interfaces.Records;
using Optivem.Framework.Infrastructure.Selenium.SystemTest.Fixtures.Records;
using System.Collections.Generic;
using System.Linq;

namespace Optivem.Framework.Infrastructure.Selenium.SystemTest.Fixtures.Data
{
    public class FakeDatabase : IDatabase
    {
        private static List<IProductRecord> InventoryRecords = new List<IProductRecord>
        {
            new ProductRecord(0, "Sauce Labs Bike Light", 9.99m),
            new ProductRecord(1, "Sauce Labs Bolt T-Shirt", 15.99m),
            new ProductRecord(2, "Sauce Labs Onesie", 7.99m),
            new ProductRecord(3, "Test.allTheThings() T-Shirt (Red)", 15.99m),
            new ProductRecord(4, "Sauce Labs Backpack", 29.99m),
            new ProductRecord(5, "Sauce Labs Fleece Jacket", 49.99m),
        };

        public List<IProductRecord> ReadProductsSortedByNameAsc()
        {
            return InventoryRecords.OrderBy(e => e.Name).ToList();
        }

        public List<IProductRecord> ReadProductsSortedByNameDesc()
        {
            return InventoryRecords.OrderByDescending(e => e.Name).ToList();
        }

        public List<IProductRecord> ReadProductsSortedByPriceAsc()
        {
            return InventoryRecords.OrderBy(e => e.PriceValue).ToList();
        }

        public List<IProductRecord> ReadProductsSortedByPriceDesc()
        {
            return InventoryRecords.OrderByDescending(e => e.PriceValue).ToList();
        }
    }
}