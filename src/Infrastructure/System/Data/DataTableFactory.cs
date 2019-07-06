using Optivem.Framework.Core.Common.Data;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Optivem.Framework.Infrastructure.System.Data
{
    public class DataTableFactory<TRecord> : IDataTableFactory<TRecord>
    {
        public DataTableFactory(IDataColumnFactory<TRecord> dataColumnFactory)
        {
            DataColumnFactory = dataColumnFactory;
        }

        public IDataColumnFactory<TRecord> DataColumnFactory { get; }

        public DataTable Create(IEnumerable<TRecord> records)
        {
            var dataTable = new DataTable();
            var dataColumns = DataColumnFactory.Create().ToArray();
            dataTable.Columns.AddRange(dataColumns);
            return dataTable;
        }
    }
}
