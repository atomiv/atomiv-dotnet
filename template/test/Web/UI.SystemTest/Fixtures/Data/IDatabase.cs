using Optivem.Template.Web.UI.SystemTest.Fixtures.Records;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Optivem.Template.Web.UI.SystemTest.Fixtures.Data
{
    public interface IDatabase
    {
        ReadOnlyCollection<InventoryItemRecord> GetInventoryItemsOrderByNameAsc();

        ReadOnlyCollection<InventoryItemRecord> GetInventoryItemsOrderByNameDesc();

        ReadOnlyCollection<InventoryItemRecord> GetInventoryItemsOrderByPriceAsc();

        ReadOnlyCollection<InventoryItemRecord> GetInventoryItemsOrderByPriceDesc();
    }
}
