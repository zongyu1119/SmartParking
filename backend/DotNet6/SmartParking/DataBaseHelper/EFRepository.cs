using Common.ObjExt;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;
using Z.EntityFramework.Plus;

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
    public class EFRepository<TDbContext,TEntity> : IEFRepository<TEntity> where TDbContext : DbContext where TEntity : Entity,new()
    {
        protected virtual TDbContext _dbContext { get; }

        protected EFRepository(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public DbContext Context { get { return _dbContext; } }
        protected virtual IQueryable<TEntity> GetDbSet(bool writeDb, bool noTracking)
        {
            if (noTracking && writeDb)
            {
                return _dbContext.Set<TEntity>().AsNoTracking().TagWith(RepositoryConsts.MAXSCALE_ROUTE_TO_MASTER);//读写分离时，指定主库
            }

            if (noTracking)
            {
                return _dbContext.Set<TEntity>().AsNoTracking();//禁用追踪，减小追踪带来的开销
            }

            if (writeDb)
            {
                return _dbContext.Set<TEntity>().TagWith(RepositoryConsts.MAXSCALE_ROUTE_TO_MASTER);//读写分离时，指定主库
            }

            return _dbContext.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression, bool writeDb = false, bool noTracking = true)
        {
            return GetDbSet(writeDb, noTracking).Where(expression);
        }

        public virtual async Task<int> InsertAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            await _dbContext.Set<TEntity>().AddAsync(entity, cancellationToken);
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task<int> InsertRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken))
        {
            await _dbContext.Set<TEntity>().AddRangeAsync(entities, cancellationToken);
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> whereExpression, bool writeDb = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            IQueryable<TEntity> source = _dbContext.Set<TEntity>().AsNoTracking();
            if (writeDb)
            {
                source = source.TagWith(RepositoryConsts.MAXSCALE_ROUTE_TO_MASTER);
            }

            return await source.AnyAsync(whereExpression, cancellationToken);
        }

        public virtual async Task<int> CountAsync(Expression<Func<TEntity, bool>> whereExpression, bool writeDb = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            IQueryable<TEntity> source = _dbContext.Set<TEntity>().AsNoTracking();
            if (writeDb)
            {
                source = source.TagWith(RepositoryConsts.MAXSCALE_ROUTE_TO_MASTER);
            }

            return await source.CountAsync(whereExpression, cancellationToken);
        }

        public virtual Task<int> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            EntityEntry<TEntity> entityEntry = _dbContext.Entry(entity);
            if (entityEntry.State == EntityState.Detached)
            {
                throw new ArgumentException("实体没有被跟踪，需要指定更新的列");
            }

            if (entityEntry.State == EntityState.Added || entityEntry.State == EntityState.Deleted)
            {
                throw new ArgumentException($"Entity,实体状态为{entityEntry.State}");
            }

            return UpdateInternalAsync(entity, cancellationToken);
        }

        protected virtual async Task<int> UpdateInternalAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }
        public virtual IQueryable<TEntity> GetAll(bool writeDb = false, bool noTracking = true)
        {
            return GetDbSet(writeDb, noTracking);
        }

        public virtual IQueryable<TrdEntity> GetAll<TrdEntity>(bool writeDb = false, bool noTracking = true) where TrdEntity : Entity
        {
            IQueryable<TrdEntity> queryable = _dbContext.Set<TrdEntity>().AsQueryable();
            if (writeDb)
            {
                queryable = queryable.TagWith(RepositoryConsts.MAXSCALE_ROUTE_TO_MASTER);
            }

            if (noTracking)
            {
                queryable = queryable.AsNoTracking();
            }

            return queryable;
        }

        public virtual async Task<TEntity?> FindAsync(long keyValue, Expression<Func<TEntity, dynamic>>? navigationPropertyPath = null, bool writeDb = false, bool noTracking = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            IQueryable<TEntity> source = from t in GetDbSet(writeDb, noTracking)
                                         where t.Id == keyValue
                                         select t;
            if (navigationPropertyPath != null)
            {
                return await source.Include(navigationPropertyPath).FirstOrDefaultAsync(cancellationToken);
            }

            return await source.FirstOrDefaultAsync(cancellationToken);
        }

        public virtual async Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, dynamic>>? navigationPropertyPath = null, Expression<Func<TEntity, object>>? orderByExpression = null, bool ascending = false, bool writeDb = false, bool noTracking = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            IQueryable<TEntity> source = GetDbSet(writeDb, noTracking).Where(whereExpression);
            if (navigationPropertyPath != null)
            {
                source = source.Include(navigationPropertyPath);
            }

            TEntity? result;
            if (orderByExpression == null)
            {
                result = await source.OrderByDescending((TEntity x) => x.Id).FirstOrDefaultAsync(cancellationToken);
            }
            else
            {
                TEntity? val = ((!ascending) ? (await source.OrderByDescending(orderByExpression).FirstOrDefaultAsync(cancellationToken)) : (await source.OrderBy(orderByExpression).FirstOrDefaultAsync(cancellationToken)));
                result = val;
            }

            return result;
        }

        public virtual async Task<TResult?> FetchAsync<TResult>(Expression<Func<TEntity, TResult>> selector, Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, object>>? orderByExpression = null, bool ascending = false, bool writeDb = false, bool noTracking = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            IQueryable<TEntity> source = GetDbSet(writeDb, noTracking).Where(whereExpression);
            TResult? result;
            if (orderByExpression == null)
            {
                result = await source.OrderByDescending((TEntity x) => x.Id).Select(selector).FirstOrDefaultAsync(cancellationToken);
            }
            else
            {
                TResult? val = ((!ascending) ? (await source.OrderByDescending(orderByExpression).Select(selector).FirstOrDefaultAsync(cancellationToken)) : (await source.OrderBy(orderByExpression).Select(selector).FirstOrDefaultAsync(cancellationToken)));
                result = val;
            }

            return result;
        }

        public virtual async Task<int> DeleteAsync(long keyValue, CancellationToken cancellationToken = default(CancellationToken))
        {
            TEntity? val = _dbContext.Set<TEntity>().Local.FirstOrDefault((TEntity x) => x.Id == keyValue);
            if (val == null)
            {
                val = new TEntity
                {
                    Id = keyValue
                };
            }

            _dbContext.Remove(val);
            try
            {
                return await _dbContext.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException)
            {
                return 0;
            }
        }

        public virtual async Task<int> UpdateAsync(TEntity entity, Expression<Func<TEntity, object>>[] updatingExpressions, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (updatingExpressions.IsNullOrEmpty())
            {
                await UpdateAsync(entity, cancellationToken);
            }

            EntityEntry<TEntity> entry = _dbContext.Entry(entity);
            if (entry.State == EntityState.Added || entry.State == EntityState.Deleted)
            {
                throw new ArgumentException($"entity,实体状态为{entry.State}");
            }

            if (entry.State == EntityState.Unchanged)
            {
                return await Task.FromResult(0);
            }

            if (entry.State == EntityState.Modified)
            {
                string?[] propNames = updatingExpressions.Select((Expression<Func<TEntity, object>> x) => x.GetMemberName()).ToArray();
                entry.Properties.ForEach(delegate (PropertyEntry propEntry)
                {
                    if (!propNames.Contains(propEntry.Metadata.Name))
                    {
                        propEntry.IsModified = false;
                    }
                });
            }

            if (entry.State == EntityState.Detached)
            {
                entry.State = EntityState.Unchanged;
                updatingExpressions.ForEach(delegate (Expression<Func<TEntity, object>> expression)
                {
                    entry.Property(expression).IsModified = true;
                });
            }

            return await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public virtual Task<int> UpdateRangeAsync(Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, TEntity>> updatingExpression, CancellationToken cancellationToken = default(CancellationToken))
        {
            Type typeFromHandle = typeof(TEntity);
            if (typeof(IConcurrency).IsAssignableFrom(typeFromHandle))
            {
                throw new ArgumentException("该实体有RowVersion列，不能使用批量更新");
            }

            return UpdateRangeInternalAsync(whereExpression, updatingExpression, cancellationToken);
        }

        public virtual async Task<int> UpdateRangeAsync(Dictionary<long, List<(string propertyName, dynamic propertyValue)>> propertyNameAndValues, CancellationToken cancellationToken = default(CancellationToken))
        {
            Dictionary<long, List<(string propertyName, dynamic propertyValue)>> propertyNameAndValues2 = propertyNameAndValues;
            IEnumerable<TEntity> enumerable = _dbContext.Set<TEntity>().Local.Where((TEntity x) => propertyNameAndValues2.ContainsKey(x.Id));
            foreach (KeyValuePair<long, List<(string, object)>> item in propertyNameAndValues2)
            {
                TEntity entity = ((enumerable != null) ? enumerable.FirstOrDefault((TEntity x) => x.Id == item.Key) : null) ?? new TEntity
                {
                    Id = item.Key
                };
                EntityEntry<TEntity> entry = _dbContext.Entry(entity);
                if (entry.State == EntityState.Detached)
                {
                    entry.State = EntityState.Unchanged;
                }

                if (entry.State == EntityState.Unchanged)
                {
                    propertyNameAndValues2.FirstOrDefault<KeyValuePair<long, List<(string, object)>>>((KeyValuePair<long, List<(string propertyName, dynamic propertyValue)>> x) => x.Key == item.Key)!.Value.ForEach(delegate ((string propertyName, dynamic propertyValue) x)
                    {
                        entry.Property(x.propertyName).CurrentValue = (object?)x.propertyValue;
                        entry.Property(x.propertyName).IsModified = true;
                    });
                }
            }

            return await _dbContext.SaveChangesAsync(cancellationToken);
        }

        protected virtual async Task<int> UpdateRangeInternalAsync(Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, TEntity>> updatingExpression, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Queryable.Where(_dbContext.Set<TEntity>(), whereExpression).UpdateAsync(updatingExpression, cancellationToken);
        }

        public virtual async Task<int> DeleteRangeAsync(Expression<Func<TEntity, bool>> whereExpression, bool isForceDel = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (isForceDel)
            {
                return await Queryable.Where(_dbContext.Set<TEntity>(), whereExpression).DeleteAsync(cancellationToken);
            }

            Type typeFromHandle = typeof(TEntity);
            if (typeof(ISoftDelete).IsAssignableFrom(typeFromHandle))
            {
                NewExpression newExpression = Expression.New(typeFromHandle);
                ParameterExpression parameterExpression = Expression.Parameter(typeFromHandle, "e");
                MemberAssignment item = Expression.Bind(typeFromHandle.GetMember("IsDeleted")[0], Expression.Constant(true));
                Expression<Func<TEntity, TEntity>> updateFactory = Expression.Lambda<Func<TEntity, TEntity>>(Expression.MemberInit(newExpression, new List<MemberBinding> { item }), new ParameterExpression[1] { parameterExpression });
                return await Queryable.Where(_dbContext.Set<TEntity>(), whereExpression).UpdateAsync(updateFactory, cancellationToken);
            }

            return await Queryable.Where(_dbContext.Set<TEntity>(), whereExpression).DeleteAsync(cancellationToken);
        }
    }
}
