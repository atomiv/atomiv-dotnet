using Optivem.Framework.Core.Domain;
using System.Linq;

namespace Optivem.Framework.Infrastructure.EntityFrameworkCore
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Page<T>(this IQueryable<T> queryable, PageQuery pageQuery)
        {
            var page = pageQuery.Page;
            var size = pageQuery.Size;

            var pageIndex = page - 1;

            var skip = pageIndex * size;

            return queryable
                .Skip(skip)
                .Take(size);
        }
    }
}
