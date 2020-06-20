using Atomiv.Infrastructure.System.Data;
using Atomiv.Infrastructure.System.IntegrationTest.Fixtures;
using Atomiv.Infrastructure.System.Reflection;
using System;
using System.Linq;
using Xunit;

namespace Atomiv.Infrastructure.System.IntegrationTest.Data
{
    public class DataColumnConverterTest
    {
        // TODO: VC: DataSet does not support nullable

        [Fact(Skip = "Check if going ahead with this method")]
        public void ToDataColumn()
        {
            var propertyFactory = new PropertyMapper<CustomerRecord>();
            var dataColumnMapper = new DataColumnMapper<CustomerRecord>(propertyFactory);

            var dataColumn = dataColumnMapper.ToDataColumn(e => e.Id);
        }

        [Fact]
        public void ToDataColumns()
        {
            var propertyFactory = new PropertyMapper<CustomerRecord>();
            var dataColumnMapper = new DataColumnMapper<CustomerRecord>(propertyFactory);

            var dataColumns = dataColumnMapper.ToDataColumns().ToList();

            Assert.Equal(6, dataColumns.Count);

            Assert.Equal("Id", dataColumns[0].ColumnName);
            Assert.Equal(typeof(int), dataColumns[0].DataType);
            Assert.False(dataColumns[0].AllowDBNull);

            Assert.Equal("FirstName", dataColumns[1].ColumnName);
            Assert.Equal(typeof(string), dataColumns[1].DataType);
            Assert.True(dataColumns[1].AllowDBNull);

            Assert.Equal("LastName", dataColumns[2].ColumnName);
            Assert.Equal(typeof(string), dataColumns[2].DataType);
            Assert.True(dataColumns[2].AllowDBNull);

            Assert.Equal("AccountBalance", dataColumns[3].ColumnName);
            Assert.Equal(typeof(decimal), dataColumns[3].DataType);
            Assert.False(dataColumns[3].AllowDBNull);

            Assert.Equal("DateJoined", dataColumns[4].ColumnName);
            Assert.Equal(typeof(DateTime), dataColumns[4].DataType);
            Assert.True(dataColumns[4].AllowDBNull);

            Assert.Equal("IsActive", dataColumns[5].ColumnName);
            Assert.Equal(typeof(bool), dataColumns[5].DataType);
            Assert.False(dataColumns[5].AllowDBNull);

            // TODO: VC: Also separate method per property, so that we can test various primitive types
        }
    }
}