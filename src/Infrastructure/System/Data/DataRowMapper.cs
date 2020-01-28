using Optivem.Atomiv.Core.Common.Data;
using Optivem.Atomiv.Core.Common.Reflection;
using System.Collections.Generic;
using System.Data;

namespace Optivem.Atomiv.Infrastructure.System.Data
{
    public class DataRowMapper<T> : IDataRowMapper<T>
    {
        public DataRowMapper(IPropertyMapper<T> propertyMapper)
        {
            PropertyMapper = propertyMapper;
        }

        public IPropertyMapper<T> PropertyMapper { get; }

        public DataRow ToDataRow(DataTable dataTable, T record)
        {
            var dataRow = dataTable.NewRow();

            var properties = PropertyMapper.GetObjectProperties(record);

            foreach (var property in properties)
            {
                var name = property.TypeProperty.Name;
                var value = property.Value;

                dataRow[name] = value;
            }

            return dataRow;
        }

        public IEnumerable<DataRow> ToDataRows(DataTable dataTable, IEnumerable<T> records)
        {
            var dataRows = new List<DataRow>();

            foreach (var record in records)
            {
                var dataRow = ToDataRow(dataTable, record);
                dataRows.Add(dataRow);
            }

            return dataRows;
        }
    }
}