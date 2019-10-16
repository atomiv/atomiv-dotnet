using Optivem.Framework.Infrastructure.System.Data;
using Optivem.Framework.Infrastructure.System.IntegrationTest.Fixtures;
using Optivem.Framework.Infrastructure.System.Reflection;
using System;
using System.Data;
using System.Linq;
using Xunit;

namespace Optivem.Framework.Infrastructure.System.IntegrationTest.Data
{
    public class DataRowConvertTest
    {
        [Fact]
        public void ToDataRow()
        {
            var customerRecord = new CustomerRecord
            {
                Id = 1,
                FirstName = "John",
                LastName = "Smith",
                AccountBalance = 25.60m,
                DateJoined = new DateTime(2018, 9, 15),
                IsActive = true,
            };

            var propertyMapper = new PropertyMapper<CustomerRecord>();
            var dataRowMapper = new DataRowMapper<CustomerRecord>(propertyMapper);
            var dataColumnMapper = new DataColumnMapper<CustomerRecord>(propertyMapper);

            var dataTable = new DataTable();

            var dataColumns = dataColumnMapper.ToDataColumns().ToArray();
            dataTable.Columns.AddRange(dataColumns);

            var dataRow = dataRowMapper.ToDataRow(dataTable, customerRecord);

            CustomerRecordAssert.Equal(customerRecord, dataRow);
        }
    }
}