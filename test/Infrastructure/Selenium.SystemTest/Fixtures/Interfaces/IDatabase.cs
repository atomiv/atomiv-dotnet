using Optivem.Framework.Infrastructure.Selenium.SystemTest.Fixtures.Interfaces.Records;
using System.Collections.Generic;

namespace Optivem.Framework.Infrastructure.Selenium.SystemTest.Fixtures.Data
{
    public interface IDatabase
    {
        List<IProductRecord> ReadProductsSortedByNameAsc();

        List<IProductRecord> ReadProductsSortedByNameDesc();

        List<IProductRecord> ReadProductsSortedByPriceAsc();

        List<IProductRecord> ReadProductsSortedByPriceDesc();
    }
}
