using System.Collections.Generic;
using System.Data;

namespace Optivem.Framework.Core.Common.Data
{
    public interface IDataColumnFactory<TRecord>
    {
        IEnumerable<DataColumn> Create();
    }
}
