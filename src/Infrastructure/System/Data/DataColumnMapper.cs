using Optivem.Framework.Core.Common.Data;
using Optivem.Framework.Core.Common.Reflection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Optivem.Framework.Infrastructure.System.Data
{
    public class DataColumnMapper<T> : IDataColumnMapper<T>
    {
        public DataColumnMapper(IPropertyMapper<T> propertyFactory)
        {
            PropertyFactory = propertyFactory;
        }

        public IPropertyMapper<T> PropertyFactory { get; }

        public IEnumerable<DataColumn> ToDataColumns()
        {
            var properties = PropertyFactory.GetTypeProperties();
            return properties.Select(e => Create(e));
        }

        public DataColumn ToDataColumn<U>(Func<T, U> propertyGetter)
        {
            var property = PropertyFactory.GetTypeProperty(propertyGetter);
            throw new NotImplementedException();
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