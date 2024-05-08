using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Linq.Expressions;
using Z.EntityFramework.Plus;
using Zy.Shared.Entitys;
using Zy.Shared.Respository.Contexts;
namespace Zy.Shared.Respository.Respositorys
{
    public class EfRespository<T>(ZyShardingCoreContext zyContext) : IEfRespository<T> where T : Entity, new()
    {
        private readonly ZyShardingCoreContext _dbContext = zyContext;

        public int Count(Expression<Func<T, bool>> expression)
        {
           return _dbContext.Set<T>().Count(expression);
        }

        public Task<int> CountAsync(Expression<Func<T, bool>> expression)
        {
            return _dbContext.Set<T>().CountAsync(expression);
        }

        public int Delete(long id) => _dbContext.Set<T>().Where(x => x.Id == id).Delete();

        public Task<int> DeleteAsync(long id)=>_dbContext.Set<T>().Where(x => x.Id == id).DeleteAsync();

        public Task<int> DeleteRangeAsync(List<T> entities) => _dbContext.Set<T>().DeleteRangeByKeyAsync(entities);

        public Task<int> DeleteRangeAsync(Expression<Func<T, bool>> expression) => _dbContext.Set<T>().Where(expression).DeleteFromQueryAsync();

        public Task<int> DeleteRangeAsync(List<long> ids) => _dbContext.Set<T>().Where(x=>ids.Contains(x.Id)).DeleteFromQueryAsync();

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

        public int Insert(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            return  _dbContext.SaveChanges();
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

        public IEnumerable<T> Tolist(Expression<Func<T, bool>> expression)
        {
            return _dbContext.Set<T>().Where(expression).ToList();
        }

        public Task<List<T>> TolistAsync(Expression<Func<T, bool>> expression)
        {
            return _dbContext.Set<T>().Where(expression).ToListAsync();
        }

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

        public IQueryable<T> Where(Expression<Func<T, bool>> expression) => _dbContext.Set<T>().Where(expression);
    }
}
