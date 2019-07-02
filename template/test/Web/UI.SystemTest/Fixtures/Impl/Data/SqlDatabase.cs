using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Optivem.Template.Web.UI.SystemTest.Fixtures.Interfaces.Records;
using Optivem.Template.Web.UI.SystemTest.Fixtures.Records;

namespace Optivem.Template.Web.UI.SystemTest.Fixtures.Data
{
    // TODO: VC: Implement SQL DB

    public class SqlDatabase : IDatabase
    {
        public List<IProductRecord> ReadProductsSortedByNameAsc()
        {
            throw new NotImplementedException();
        }

        public List<IProductRecord> ReadProductsSortedByNameDesc()
        {
            throw new NotImplementedException();
        }

        public List<IProductRecord> ReadProductsSortedByPriceAsc()
        {
            throw new NotImplementedException();
        }

        public List<IProductRecord> ReadProductsSortedByPriceDesc()
        {
            throw new NotImplementedException();
        }
    }
}
