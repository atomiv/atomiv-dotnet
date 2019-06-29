using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Optivem.Template.Web.UI.SystemTest.Fixtures.Records;

namespace Optivem.Template.Web.UI.SystemTest.Fixtures.Data
{
    public class FakeDatabase : IDatabase
    {
        private static List<InventoryItemRecord> InventoryRecords = new List<InventoryItemRecord>
        {
            new InventoryItemRecord(0, "Sauce Labs Bike Light", 9.99m),
            new InventoryItemRecord(1, "Sauce Labs Bolt T-Shirt", 15.99m),
            new InventoryItemRecord(2, "Sauce Labs Onesie", 7.99m),
            new InventoryItemRecord(3, "Test.allTheThings() T-Shirt (Red)", 15.99m),
            new InventoryItemRecord(4, "Sauce Labs Backpack", 29.99m),
            new InventoryItemRecord(5, "Sauce Labs Fleece Jacket", 49.99m),
        };

        public ReadOnlyCollection<InventoryItemRecord> GetInventoryItemsOrderByNameAsc()
        {
            return InventoryRecords.OrderBy(e => e.Name).ToList().AsReadOnly();
        }

        public ReadOnlyCollection<InventoryItemRecord> GetInventoryItemsOrderByNameDesc()
        {
            return InventoryRecords.OrderByDescending(e => e.Name).ToList().AsReadOnly();
        }

        public ReadOnlyCollection<InventoryItemRecord> GetInventoryItemsOrderByPriceAsc()
        {
            return InventoryRecords.OrderBy(e => e.PriceValue).ToList().AsReadOnly();
        }

        public ReadOnlyCollection<InventoryItemRecord> GetInventoryItemsOrderByPriceDesc()
        {
            return InventoryRecords.OrderByDescending(e => e.PriceValue).ToList().AsReadOnly();
        }
    }
}
