using Optivem.Atomiv.Infrastructure.System.Data;
using Optivem.Atomiv.Infrastructure.System.IntegrationTest.Fixtures;
using Optivem.Atomiv.Infrastructure.System.Reflection;
using System;
using System.Collections.Generic;
using Xunit;

namespace Optivem.Atomiv.Infrastructure.System.IntegrationTest.Data
{
    public class DataTableConverterTest
    {
        [Fact]
        public void ToDataTableNoRows()
        {
            var customerRecords = new List<CustomerRecord>();

            var propertyMapper = new PropertyMapper<CustomerRecord>();
            var dataColumnMapper = new DataColumnMapper<CustomerRecord>(propertyMapper);
            var dataRowMapper = new DataRowMapper<CustomerRecord>(propertyMapper);
            var dataTableMapper = new DataTableMapper<CustomerRecord>(dataColumnMapper, dataRowMapper);

            var dataTable = dataTableMapper.ToDataTable(customerRecords);

            Assert.Equal(customerRecords.Count, dataTable.Rows.Count);

            Assert.Equal(6, dataTable.Columns.Count);

            Assert.Equal(0, dataTable.Rows.Count);
        }

        [Fact]
        public void ToDataTableWithMultipleRows()
        {
            var customerRecords = new List<CustomerRecord>
            {
                new CustomerRecord
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Smith",
                    AccountBalance = 25.60m,
                    DateJoined = new DateTime(2018, 9, 15),
                    IsActive = true,
                },

                new CustomerRecord
                {
                    Id = 2,
                    FirstName = "Mary",
                    LastName = "McDonanld",
                    AccountBalance = 30.950m,
                    DateJoined = new DateTime(2017, 4, 10),
                    IsActive = false,
                }
            };

            var propertyMapper = new PropertyMapper<CustomerRecord>();
            var dataColumnMapper = new DataColumnMapper<CustomerRecord>(propertyMapper);
            var dataRowMapper = new DataRowMapper<CustomerRecord>(propertyMapper);
            var dataTableMapper = new DataTableMapper<CustomerRecord>(dataColumnMapper, dataRowMapper);

            var dataTable = dataTableMapper.ToDataTable(customerRecords);

            Assert.Equal(customerRecords.Count, dataTable.Rows.Count);

            Assert.Equal(6, dataTable.Columns.Count);

            // TODO: VC: Assert columns equality

            CustomerRecordAssert.Equal(customerRecords, dataTable.Rows);
        }
    }
}