using Optivem.Template.Web.UI.SystemTest.Fixtures.Interfaces.Records;
using System.Collections.Generic;

namespace Optivem.Template.Web.UI.SystemTest.Fixtures.Data
{
    public interface IDatabase
    {
        List<IProductRecord> ReadProductsSortedByNameAsc();

        List<IProductRecord> ReadProductsSortedByNameDesc();

        List<IProductRecord> ReadProductsSortedByPriceAsc();

        List<IProductRecord> ReadProductsSortedByPriceDesc();
    }
}
