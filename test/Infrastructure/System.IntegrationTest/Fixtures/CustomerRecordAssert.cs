using System.Collections.Generic;
using System.Data;
using System.Linq;
using Xunit;

namespace Optivem.Framework.Infrastructure.System.IntegrationTest.Fixtures
{
    public static class CustomerRecordAssert
    {
        public static void Equal(CustomerRecord expectedRecord, DataRow actualRow)
        {
            Assert.Equal(expectedRecord.Id, actualRow["Id"]);
            Assert.Equal(expectedRecord.FirstName, actualRow["FirstName"]);
            Assert.Equal(expectedRecord.LastName, actualRow["LastName"]);
            Assert.Equal(expectedRecord.AccountBalance, actualRow["AccountBalance"]);
            Assert.Equal(expectedRecord.DateJoined, actualRow["DateJoined"]);
            Assert.Equal(expectedRecord.IsActive, actualRow["IsActive"]);
        }

        public static void Equal(IEnumerable<CustomerRecord> expectedRecords, DataRowCollection actualRows)
        {
            Assert.Equal(expectedRecords.Count(), actualRows.Count);

            var count = expectedRecords.Count();

            for (int i = 0; i < count; i++)
            {
                var expectedRecord = expectedRecords.ElementAt(i);
                var actualRecord = actualRows[i];

                Equal(expectedRecord, actualRecord);
            }

        }
    }
}
