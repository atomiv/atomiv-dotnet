using Optivem.Framework.Core.Common.Data;
using Optivem.Framework.Core.Common.Reflection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Optivem.Framework.Infrastructure.System.Data
{
    public class DataColumnFactory<TRecord> : IDataColumnFactory<TRecord>
    {
        public DataColumnFactory(IPropertyFactory<TRecord> propertyFactory)
        {
            PropertyFactory = propertyFactory;
        }

        public IPropertyFactory<TRecord> PropertyFactory { get; }

        public IEnumerable<DataColumn> Create()
        {
            var properties = PropertyFactory.Create();
            return properties.Select(e => Create(e));
        }

        private DataColumn Create(ITypeProperty property)
        {
            var name = property.Name;
            var type = property.Type;

            var underlyingNullableType = Nullable.GetUnderlyingType(type);
            var isNullable = underlyingNullableType != null;
            var dataColumnType = isNullable ? underlyingNullableType : type;

            var dataColumn = new DataColumn(name, dataColumnType);

            dataColumn.AllowDBNull = isNullable || !type.IsValueType;

            return dataColumn;
        }
    }
}
