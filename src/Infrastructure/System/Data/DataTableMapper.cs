using Optivem.Framework.Core.Common.Data;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Optivem.Framework.Infrastructure.System.Data
{
    public class DataTableMapper<T> : IDataTableMapper<T>
    {
        public DataTableMapper(IDataColumnMapper<T> dataColumnMapper, IDataRowMapper<T> dataRowMapper)
        {
            DataColumnMapper = dataColumnMapper;
            DataRowMapper = dataRowMapper;
        }

        public IDataColumnMapper<T> DataColumnMapper { get; }

        public IDataRowMapper<T> DataRowMapper { get; }

        public IEnumerable<T> FromDataTable(DataTable dataTable)
        {
            throw new global::System.NotImplementedException();
        }

        public DataTable ToDataTable(IEnumerable<T> records)
        {
            var dataTable = new DataTable();

            var dataColumns = DataColumnMapper.ToDataColumns().ToArray();
            dataTable.Columns.AddRange(dataColumns);

            var dataRows = DataRowMapper.ToDataRows(dataTable, records).ToArray();

            foreach (var dataRow in dataRows)
            {
                dataTable.Rows.Add(dataRow);
            }

            return dataTable;
        }
    }
}