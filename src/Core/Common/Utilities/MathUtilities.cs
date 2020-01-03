using System;

namespace Optivem.Framework.Core.Common.Utilities
{
    public static class MathUtilities
    {
        public static long GetTotalPages(long totalRecords, int pageSize)
        {
            var totalPagesDecimal = (decimal)totalRecords / pageSize;
            var totalPages = (long)Math.Ceiling(totalPagesDecimal);

            return totalPages;
        }
    }
}
