using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Optivem.Template.Web.UI.SystemTest.Fixtures.Records;

namespace Optivem.Template.Web.UI.SystemTest.Fixtures.Data
{
    // TODO: VC: Implement SQL DB

    public class SqlDatabase : IDatabase
    {
        public ReadOnlyCollection<InventoryItemRecord> GetInventoryItemsOrderByNameAsc()
        {
            throw new NotImplementedException();
        }

        public ReadOnlyCollection<InventoryItemRecord> GetInventoryItemsOrderByNameDesc()
        {
            throw new NotImplementedException();
        }

        public ReadOnlyCollection<InventoryItemRecord> GetInventoryItemsOrderByPriceAsc()
        {
            throw new NotImplementedException();
        }

        public ReadOnlyCollection<InventoryItemRecord> GetInventoryItemsOrderByPriceDesc()
        {
            throw new NotImplementedException();
        }
    }
}
