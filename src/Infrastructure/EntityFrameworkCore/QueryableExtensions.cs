using System.Linq;

namespace Atomiv.Infrastructure.EntityFrameworkCore
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> GetPage<T>(this IQueryable<T> queryable, int page, int size)
        {
            var pageIndex = page - 1;

            var skip = pageIndex * size;

            return queryable
                .Skip(skip)
                .Take(size);
        }
    }
}
