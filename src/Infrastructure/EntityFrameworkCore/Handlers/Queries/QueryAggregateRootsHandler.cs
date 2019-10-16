namespace Optivem.Framework.Infrastructure.EntityFrameworkCore
{
    internal class QueryAggregateRootsHandler
    {
    }

    // TODO: VC: CHECK
    /*

    #region Helper - Read

    protected IQueryable<TAggregateRoot> GetQuery(Expression<Func<TAggregateRoot, bool>> filter = null,
        Func<IQueryable<TAggregateRoot>, IOrderedQueryable<TAggregateRoot>> orderBy = null,
        int? skip = null,
        int? take = null,
        params Expression<Func<TAggregateRoot, object>>[] includes)
    {
        var query = set.AsQueryable();

        if (filter != null)
        {
            query = query.Where(filter);
        }

        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        if (orderBy != null)
        {
            query = orderBy(query);
        }

        if (skip != null)
        {
            query = query.Skip(skip.Value);
        }

        if (take != null)
        {
            query = query.Take(take.Value);
        }

        return query;
    }

    protected IQueryable<TAggregateRoot> GetQuery(Expression<Func<TAggregateRoot, bool>> filter = null,
        params Expression<Func<TAggregateRoot, object>>[] includes)
    {
        return GetQuery(filter, null, null, null, includes);
    }

    protected IEnumerable<TAggregateRoot> GetEntities<T>(IEnumerable<T> ids)
    {
        var entities = new List<TAggregateRoot>();

        foreach (var id in ids)
        {
            var entity = GetSingleOrDefaultInner(id);

            if (entity != null)
            {
                entities.Add(entity);
            }
        }

        return entities;
    }

    #endregion Helper - Read

    */

    // TODO: VC: RECHECK

    /*
    public IEnumerable<TAggregateRoot> Get(Expression<Func<TAggregateRoot, bool>> filter = null,
        Func<IQueryable<TAggregateRoot>, IOrderedQueryable<TAggregateRoot>> orderBy = null,
        int? skip = null, int? take = null,
        params Expression<Func<TAggregateRoot, object>>[] includes)
    {
        var query = GetQuery(filter, orderBy, skip, take, includes);
        return query.ToList();
    }

    public async Task<IEnumerable<TAggregateRoot>> GetAsync(Expression<Func<TAggregateRoot, bool>> filter = null,
        Func<IQueryable<TAggregateRoot>, IOrderedQueryable<TAggregateRoot>> orderBy = null,
        int? skip = null, int? take = null,
        params Expression<Func<TAggregateRoot, object>>[] includes)
    {
        var query = GetQuery(filter, orderBy, skip, take, includes);
        return await query.ToListAsync();
    }

    public TAggregateRoot GetSingle(Expression<Func<TAggregateRoot, bool>> filter = null, params Expression<Func<TAggregateRoot, object>>[] includes)
    {
        var query = GetQuery(filter, includes);
        return query.Single();
    }

    public Task<TAggregateRoot> GetSingleAsync(Expression<Func<TAggregateRoot, bool>> filter = null, params Expression<Func<TAggregateRoot, object>>[] includes)
    {
        var query = GetQuery(filter, includes);
        return query.SingleAsync();
    }

    public TAggregateRoot GetSingleOrDefault(Expression<Func<TAggregateRoot, bool>> filter = null, params Expression<Func<TAggregateRoot, object>>[] includes)
    {
        var query = GetQuery(filter, includes);
        return query.SingleOrDefault();
    }

    public Task<TAggregateRoot> GetSingleOrDefaultAsync(Expression<Func<TAggregateRoot, bool>> filter = null, params Expression<Func<TAggregateRoot, object>>[] includes)
    {
        var query = GetQuery(filter, includes);
        return query.SingleOrDefaultAsync();
    }

    public TAggregateRoot GetFirst(Expression<Func<TAggregateRoot, bool>> filter = null, params Expression<Func<TAggregateRoot, object>>[] includes)
    {
        var query = GetQuery(filter, includes);
        return query.First();
    }

    public Task<TAggregateRoot> GetFirstAsync(Expression<Func<TAggregateRoot, bool>> filter = null, params Expression<Func<TAggregateRoot, object>>[] includes)
    {
        var query = GetQuery(filter, includes);
        return query.FirstAsync();
    }

    public TAggregateRoot GetFirstOrDefault(Expression<Func<TAggregateRoot, bool>> filter = null, params Expression<Func<TAggregateRoot, object>>[] includes)
    {
        var query = GetQuery(filter, includes);
        return query.FirstOrDefault();
    }

    public Task<TAggregateRoot> GetFirstOrDefaultAsync(Expression<Func<TAggregateRoot, bool>> filter = null, params Expression<Func<TAggregateRoot, object>>[] includes)
    {
        var query = GetQuery(filter, includes);
        return query.FirstOrDefaultAsync();
    }

    public long GetCount(Expression<Func<TAggregateRoot, bool>> filter = null)
    {
        var query = GetQuery(filter);
        return query.LongCount();
    }

    public Task<long> GetCountAsync(Expression<Func<TAggregateRoot, bool>> filter = null)
    {
        var query = GetQuery(filter);
        return query.LongCountAsync();
    }

    public bool GetExists(Expression<Func<TAggregateRoot, bool>> filter = null)
    {
        var query = GetQuery(filter);
        return query.Any();
    }

    public Task<bool> GetExistsAsync(Expression<Func<TAggregateRoot, bool>> filter = null)
    {
        var query = GetQuery(filter);
        return query.AnyAsync();
    }

    */
}