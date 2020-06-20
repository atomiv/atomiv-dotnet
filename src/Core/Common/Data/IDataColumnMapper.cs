using System;
using System.Collections.Generic;
using System.Data;

namespace Atomiv.Core.Common.Data
{
    public interface IDataColumnMapper<T>
    {
        DataColumn ToDataColumn<U>(Func<T, U> propertyGetter);

        IEnumerable<DataColumn> ToDataColumns();
    }
}