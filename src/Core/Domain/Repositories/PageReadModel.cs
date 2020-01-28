using System;
using System.Collections.Generic;

namespace Optivem.Atomiv.Core.Domain
{
    public class PageReadModel<T>
    {
        public PageReadModel(IEnumerable<T> records, long totalRecords, long totalPages)
        {
            Records = records;
            TotalPages = totalPages;
            TotalRecords = totalRecords;
        }

        public IEnumerable<T> Records { get; }

        public long TotalRecords { get; }

        public long TotalPages { get; }

        public static PageReadModel<T> Create(PageQuery pageQuery, IEnumerable<T> records, long totalRecords)
        {
            var size = pageQuery.Size;

            var totalPagesDecimal = (decimal)totalRecords / size;
            var totalPages = (long)Math.Ceiling(totalPagesDecimal);

            return new PageReadModel<T>(records, totalRecords, totalPages);
        }
    }
}
