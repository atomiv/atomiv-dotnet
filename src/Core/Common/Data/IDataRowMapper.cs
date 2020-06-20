using System.Collections.Generic;
using System.Data;

namespace Atomiv.Core.Common.Data
{
    public interface IDataRowMapper<T>
    {
        DataRow ToDataRow(DataTable dataTable, T record);

        IEnumerable<DataRow> ToDataRows(DataTable dataTable, IEnumerable<T> records);
    }
}