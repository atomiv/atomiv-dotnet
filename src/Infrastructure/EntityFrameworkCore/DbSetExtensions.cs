namespace Optivem.Atomiv.Infrastructure.EntityFrameworkCore
{
    /*

    public static class DbSetExtensions
    {
        public static Task<bool> ExistsAsync<TRecord, TId>(this DbSet<TRecord> set, IIdentity<TId> id)
            where TRecord : class, IRecord<TId>
            where TId : IEquatable<TId>
        {
            var recordId = id.Id;

            return set.AsNoTracking()
                .AnyAsync(e => e.Id.Equals(recordId));
        }

        public static Task<TRecord> FindAsync<TRecord, TId>(this DbSet<TRecord> set, IIdentity<TId> id, Func<IQueryable<TRecord>, IQueryable<TRecord>> queryableFunc = null)
            where TRecord : class, IRecord<TId>
            where TId : IEquatable<TId>
        {
            var recordId = id.Id;

            var queryable = GetQueryable(set, queryableFunc);

            return queryable.AsNoTracking()
                .SingleOrDefaultAsync(e => e.Id.Equals(recordId));
        }

        public static async Task<TResult> FindAsync<TRecord, TId, TResult>(this DbSet<TRecord> set, IIdentity<TId> id, Func<TRecord, TResult> mapper, Func<IQueryable<TRecord>, IQueryable<TRecord>> queryableFunc = null)
            where TRecord : class, IRecord<TId>
            where TId : IEquatable<TId>
            where TResult : class
        {
            var record = await FindAsync(set, id, queryableFunc);

            if(record == null)
            {
                return null;
            }

            return mapper(record);
        }


        // TODO: VC: Add query predicate and sort

        public static async Task<PageReadModel<TRecord>> GetPageAsync<TRecord>(this DbSet<TRecord> set, PageQuery pageQuery, Func<IQueryable<TRecord>, IQueryable<TRecord>> queryableFunc = null)
            where TRecord : class
        {
            var page = pageQuery.Page;
            var size = pageQuery.Size;

            var pageIndex = page - 1;

            var skip = pageIndex * size;

            var queryable = GetQueryable(set, queryableFunc);

            var records = await queryable
                .AsNoTracking()
                .Skip(skip)
                .Take(size)
                .ToListAsync();

            var totalRecords = await set
                .CountAsync();

            var totalPagesDecimal = (decimal)totalRecords / size;
            var totalPages = (int)Math.Ceiling(totalPagesDecimal);

            return new PageReadModel<TRecord>(records, totalPages, totalRecords);
        }





        public static async Task<PageReadModel<TResult>> GetPageAsync<TRecord, TResult>(this DbSet<TRecord> set, PageQuery pageQuery, Func<TRecord, TResult> mapper, Func<IQueryable<TRecord>, IQueryable<TRecord>> queryableFunc = null)
            where TRecord : class
        {
            var page = await set.GetPageAsync(pageQuery, queryableFunc);
            var data = page.Records.Select(mapper).ToList();

            return new PageReadModel<TResult>(data, page.TotalPages, page.TotalRecords);
        }

        // TODO: VC: Insert limit and filtering, e.g. like for autocomplete, search substring and return limited  results e.g. 20

        // TODO: VC: Returning long count

        public static async Task<ListReadModel<IdNameReadModel<TId>>> ListIdNamesAsync<TRecord, TId>(this DbSet<TRecord> set, Func<TRecord, string> getName)
            where TRecord : class, IRecord<TId>
        {
            var records = await set.AsNoTracking()
                .Select(e => new IdNameReadModel<TId>(e.Id, getName(e)))
                .ToListAsync();

            var totalRecords = await set.AsNoTracking()
                .CountAsync();

            return new ListReadModel<IdNameReadModel<TId>>(records, totalRecords);
        }





        // TODO: VC: DELETE

        /*
        private static IQueryable<TRecord> GetIncludedQueryable<TRecord>(IQueryable<TRecord> queryable, IEnumerable<Expression<Func<TRecord, object>>> includes = null)
            where TRecord : class
        {
            if(includes == null)
            {
                return queryable;
            }

            foreach (var include in includes)
            {
                queryable = queryable.Include(include);
            }

            return queryable;
        }


        private static IQueryable<TRecord> GetQueryable<TRecord>(IQueryable<TRecord> queryable, Func<IQueryable<TRecord>, IQueryable<TRecord>> queryableFunc = null)
        {
            if(queryableFunc == null)
            {
                return queryable;
            }

            return queryableFunc(queryable);
        }
    }

    */
}
