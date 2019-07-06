using System.Collections.Generic;
using System.Data;

namespace Optivem.Framework.Core.Common.Data
{
    public interface IDataTableFactory<TRecord>
    {
        DataTable Create(IEnumerable<TRecord> records);
    }
}
