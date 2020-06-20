using System.Collections.Generic;

namespace Atomiv.Core.Domain
{
    public class ListReadModel<T>
    {
        public ListReadModel(IEnumerable<T> records, long totalRecords)
        {
            Records = records;
            TotalRecords = totalRecords;
        }

        public IEnumerable<T> Records { get; }

        public long TotalRecords { get; }
    }
}
