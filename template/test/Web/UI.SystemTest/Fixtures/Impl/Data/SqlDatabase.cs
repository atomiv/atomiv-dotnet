using System;
using System.Collections.Generic;
using Optivem.Framework.Infrastructure.Selenium.SystemTest.Fixtures.Interfaces.Records;

namespace Optivem.Framework.Infrastructure.Selenium.SystemTest.Fixtures.Data
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
