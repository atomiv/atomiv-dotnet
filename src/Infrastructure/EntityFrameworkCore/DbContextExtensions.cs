using Microsoft.EntityFrameworkCore;
using Optivem.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Optivem.Framework.Infrastructure.EntityFrameworkCore
{
    public static class DbContextExtensions
    {
        // TODO: VC: Implement AddRange, UpdateRange, DeleteRange

        public static async Task<TRecord> AddAsync<TRecord, TEntity>(this DbContext context, TEntity entity, Func<TEntity, TRecord> mapper)
        {
            var record = mapper(entity);
            await context.AddAsync(record);
            return record;
        }

        public static async Task<TEntity> AddAsync<TRecord, TEntity>(this DbContext context, TEntity entity, Func<TEntity, TRecord> mapper, Func<TRecord, TEntity> reverseMapper)
        {
            var record = await context.AddAsync(entity, mapper);
            await context.SaveChangesAsync();
            return reverseMapper(record);
        }

        public static void Remove<TRecord, TId>(this DbContext context, IIdentity<TId> id)
            where TRecord : class, IRecord<TId>, new()
        {
            var recordId = id.Id;

            var record = new TRecord
            {
                Id = recordId,
            };

            context.Remove(record);
        }

        public static async Task RemoveAsync<TRecord, TId>(this DbContext context, IIdentity<TId> id)
            where TRecord : class, IRecord<TId>, new()
        {
            context.Remove(id);
            await context.SaveChangesAsync();
        }

        public static async Task<TRecord> UpdateAsync<TRecord, TEntity, TIdentity, TId>(this DbContext context, TEntity entity, Action<TEntity, TRecord> mapper, List<Expression<Func<TRecord, object>>> includes = null)
            where TRecord : class, IRecord<TId>
            where TEntity : IEntity<TIdentity>
            where TIdentity : IIdentity<TId>
            where TId : IEquatable<TId>
        {
            var recordId = entity.Id;

            var mutableSet = context.Set<TRecord>();

            var mutableQueryable = mutableSet.AsQueryable();

            if(includes != null)
            {
                foreach(var include in includes)
                {
                    mutableQueryable = mutableQueryable.Include(include);
                }
            }

            var record = await mutableQueryable.SingleOrDefaultAsync(e => e.Id.Equals(recordId));

            if(record == null)
            {
                return null;
            }

            mapper(entity, record);

            try
            {
                mutableSet.Update(record);
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new ConcurrentUpdateException(ex.Message, ex);
            }

            return record;
        }

        public static async Task<TEntity> UpdateAsync<TRecord, TEntity, TIdentity, TId>(this DbContext context, TEntity entity, Action<TEntity, TRecord> mapper, Func<TRecord, TEntity> reverseMapper, List<Expression<Func<TRecord, object>>> includes = null)
            where TRecord : class, IRecord<TId>
            where TEntity : class, IEntity<TIdentity>
            where TIdentity : IIdentity<TId>
            where TId : IEquatable<TId>
        {
            var record = await context.UpdateAsync<TRecord, TEntity, TIdentity, TId>(entity, mapper, includes);
            
            if(record == null)
            {
                return null;
            }
            
            await context.SaveChangesAsync();

            return reverseMapper(record);
        }
    }
}
