using Optivem.Framework.Infrastructure.System.Data;
using Optivem.Framework.Infrastructure.System.IntegrationTest.Fixtures;
using Optivem.Framework.Infrastructure.System.Reflection;
using System.Collections.Generic;
using Xunit;

namespace Optivem.Framework.Infrastructure.System.IntegrationTest.Data
{
    public class DataTableFactoryTest
    {
        [Fact]
        public void TestCreate()
        {
            var customerRecords = new List<CustomerRecord>();

            var propertyFactory = new PropertyFactory<CustomerRecord>();
            var dataColumnFactory = new DataColumnFactory<CustomerRecord>(propertyFactory);
            var dataTableFactory = new DataTableFactory<CustomerRecord>(dataColumnFactory);

            var dataTable = dataTableFactory.Create(customerRecords);

            Assert.Equal(customerRecords.Count, dataTable.Rows.Count);

            Assert.Equal(6, dataTable.Columns.Count);

            // TODO: VC: Test rows
        }


    }
}
