using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

/// <summary>
///  Namespace: Service.Comm
///  Name： Repository
///  Author: zy
///  Time:  2022-04-02 23:24:00
///  Version:  0.1
/// </summary>

namespace DataBaseHelper
{
    /// <summary>
    /// 资源库
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EFRepository<TDbContext,TEntity> : IEFRepository<TEntity> where TDbContext : DbContext where TEntity : Entity
    {
        protected virtual TDbContext DbContext { get; }

        protected EFRepository(TDbContext dbContext)
        {
            DbContext = dbContext;
        }

        protected virtual IQueryable<TEntity> GetDbSet(bool writeDb, bool noTracking)
        {
            if (noTracking && writeDb)
            {
                return DbContext.Set<TEntity>().AsNoTracking().TagWith(RepositoryConsts.MAXSCALE_ROUTE_TO_MASTER);
            }

            if (noTracking)
            {
                return DbContext.Set<TEntity>().AsNoTracking();
            }

            if (writeDb)
            {
                return DbContext.Set<TEntity>().TagWith(RepositoryConsts.MAXSCALE_ROUTE_TO_MASTER);
            }

            return DbContext.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression, bool writeDb = false, bool noTracking = true)
        {
            return GetDbSet(writeDb, noTracking).Where(expression);
        }

        public virtual async Task<int> InsertAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            await DbContext.Set<TEntity>().AddAsync(entity, cancellationToken);
            return await DbContext.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task<int> InsertRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken))
        {
            await DbContext.Set<TEntity>().AddRangeAsync(entities, cancellationToken);
            return await DbContext.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> whereExpression, bool writeDb = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            IQueryable<TEntity> source = DbContext.Set<TEntity>().AsNoTracking();
            if (writeDb)
            {
                source = source.TagWith(RepositoryConsts.MAXSCALE_ROUTE_TO_MASTER);
            }

            return await source.AnyAsync(whereExpression, cancellationToken);
        }

        public virtual async Task<int> CountAsync(Expression<Func<TEntity, bool>> whereExpression, bool writeDb = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            IQueryable<TEntity> source = DbContext.Set<TEntity>().AsNoTracking();
            if (writeDb)
            {
                source = source.TagWith(RepositoryConsts.MAXSCALE_ROUTE_TO_MASTER);
            }

            return await source.CountAsync(whereExpression, cancellationToken);
        }

        public virtual Task<int> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            EntityEntry<TEntity> entityEntry = DbContext.Entry(entity);
            if (entityEntry.State == EntityState.Detached)
            {
                throw new ArgumentException("实体没有被跟踪，需要指定更新的列");
            }

            if (entityEntry.State == EntityState.Added || entityEntry.State == EntityState.Deleted)
            {
                throw new ArgumentException("entity,实体状态为State");
            }

            return UpdateInternalAsync(entity, cancellationToken);
        }

        protected virtual async Task<int> UpdateInternalAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await DbContext.SaveChangesAsync(cancellationToken);
        }

    }
}
