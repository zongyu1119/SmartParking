using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using Z.EntityFramework.Plus;
using Zy.Shared.Entitys;
using Zy.Shared.Repository.Contexts;
namespace Zy.Shared.Repository.Repositorys
{
    public class EfRepository<T>(ZyShardingCoreDbContext zyContext) : IEfRepository<T> where T : Entity, new()
    {
        private readonly ZyShardingCoreDbContext _dbContext = zyContext;

        public int Count(Expression<Func<T, bool>> expression)
        {
            if(typeof(T).IsAssignableFrom(typeof(ISoftDeleted)))
                expression
           return _dbContext.Set<T>().Count(expression);
        }

        public Task<int> CountAsync(Expression<Func<T, bool>> expression)
        {
            return _dbContext.Set<T>().CountAsync(expression);
        }

        public int Delete(long id) => _dbContext.Set<T>().Where(x => x.Id == id).Delete();

        public async Task<int> DeleteAsync(long id)
        {
            int rows = 0;
            //查询当前上下文中，有没有同Id实体
            var entity = _dbContext.Set<T>().Local.FirstOrDefault(x => x.Id == id);

            if (entity == null)
                entity = new T { Id = id };
            var enityType = typeof(T);
            var hasSoftDeleteMember = typeof(ISoftDeleted).IsAssignableFrom(enityType);
            if (hasSoftDeleteMember)
            {
                ((ISoftDeleted)entity).IsDeleted = true;
            }
            else
            {
                _dbContext.Remove(entity);
            }
            try
            {
                rows = await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                rows = 0;
            }
            return rows;
        } 

        public Task<int> DeleteRangeAsync(List<T> entities) => _dbContext.Set<T>().DeleteRangeByKeyAsync(entities);

        public Task<int> DeleteRangeAsync(Expression<Func<T, bool>> expression) => _dbContext.Set<T>().Where(expression).DeleteFromQueryAsync();

        public Task<int> DeleteRangeAsync(List<long> ids) => _dbContext.Set<T>().Where(x=>ids.Contains(x.Id)).DeleteFromQueryAsync();

        public int Update(T entity, Expression<Func<T, object>>[] updatedProperties)
        {
            _dbContext.Set<T>().Attach(entity);
            if (updatedProperties.Any())
            {
                foreach (var property in updatedProperties)
                {
                    _dbContext.Entry<T>(entity).Property(property).IsModified = true;
                }
            }
            return _dbContext.SaveChanges();
        }

        public Task<int> UpdateAsync(T entity, Expression<Func<T, object>>[] updatedProperties)
        {
            _dbContext.Set<T>().Attach(entity);
            if (updatedProperties.Length != 0)
            {
                foreach (var property in updatedProperties)
                {
                    _dbContext.Entry<T>(entity).Property(property).IsModified = true;
                }
            }
            return _dbContext.SaveChangesAsync();
        }

        public Task<int> UpdateRangeAsync(List<T> entities, Expression<Func<T, object>>[] updatedProperties)
        {
            entities.ForEach(entity =>
            {
                _dbContext.Set<T>().Attach(entity);
                if (updatedProperties.Length != 0)
                {
                    foreach (var property in updatedProperties)
                    {
                        _dbContext.Entry<T>(entity).Property(property).IsModified = true;
                    }
                }
            });
            return _dbContext.SaveChangesAsync();
        }
        public int Insert(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            return _dbContext.SaveChanges();
        }

        public async Task<int> InsertAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> InsertRangeAsync(List<T> entities)
        {
            _dbContext.Set<T>().AddRange(entities);
            return await _dbContext.SaveChangesAsync();
        }
        public T Find(Expression<Func<T, bool>> expression)
        {
            return _dbContext.Set<T>().FirstOrDefault(expression);
        }

        public T Find(long id)
        {
            return _dbContext.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public  Task<T?> FindAsync(Expression<Func<T, bool>> expression)
        {
            return  _dbContext.Set<T>().FirstOrDefaultAsync(expression);
        }

        public Task<T> FindAsync(long id)
        {
            return _dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> expression)
        {
            return _dbContext.Set<T>().FirstOrDefault(expression);
        }

        public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression)
        {
            return _dbContext.Set<T>().FirstOrDefaultAsync(expression);
        }

        public IQueryable<T> GetAll() => _dbContext.Set<T>();


        public IEnumerable<T> Tolist(Expression<Func<T, bool>> expression)
        {
            return _dbContext.Set<T>().Where(expression).ToList();
        }

        public Task<List<T>> TolistAsync(Expression<Func<T, bool>> expression)
        {
            return _dbContext.Set<T>().Where(expression).ToListAsync();
        }


        public IQueryable<T> Where(Expression<Func<T, bool>> expression) => _dbContext.Set<T>().Where(expression);
    }
}
