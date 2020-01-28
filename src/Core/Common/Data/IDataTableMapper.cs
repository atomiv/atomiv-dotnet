using System.Collections.Generic;
using System.Data;

namespace Optivem.Atomiv.Core.Common.Data
{
    public interface IDataTableMapper<T>
    {
        DataTable ToDataTable(IEnumerable<T> records);

        IEnumerable<T> FromDataTable(DataTable dataTable);
    }
}