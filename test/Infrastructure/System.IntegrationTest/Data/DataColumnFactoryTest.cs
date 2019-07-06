using Optivem.Framework.Infrastructure.System.Data;
using Optivem.Framework.Infrastructure.System.IntegrationTest.Fixtures;
using Optivem.Framework.Infrastructure.System.Reflection;
using System;
using System.Linq;
using Xunit;

namespace Optivem.Framework.Infrastructure.System.IntegrationTest.Data
{
    public class DataColumnFactoryTest
    {
        // TODO: VC: DataSet does not support nullable

        [Fact]
        public void TestCreate()
        {
            var propertyFactory = new PropertyFactory<CustomerRecord>();
            var dataColumnFactory = new DataColumnFactory<CustomerRecord>(propertyFactory);

            var dataColumns = dataColumnFactory.Create().ToList();

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
