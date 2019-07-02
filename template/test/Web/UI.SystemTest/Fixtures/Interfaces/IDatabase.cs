using Optivem.Template.Web.UI.SystemTest.Fixtures.Interfaces.Records;
using Optivem.Template.Web.UI.SystemTest.Fixtures.Records;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

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
