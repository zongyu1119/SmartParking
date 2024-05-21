using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Zy.Shared.Entitys;

namespace Zy.Shared.Repository.Repositorys
{
    /// <summary>
    /// 全功能的EF库
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEfRepository<T> where T : Entity, new()
    {
        #region Query
        IEnumerable<T> Tolist(Expression<Func<T, bool>> expression);
        Task<List<T>> TolistAsync(Expression<Func<T,bool>> expression);
        int Count(Expression<Func<T, bool>> expression);
        Task<int> CountAsync(Expression<Func<T, bool>> expression);

        T FirstOrDefault(Expression<Func<T, bool>> expression);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression);
        T Find(Expression<Func<T, bool>> expression);
        Task<T?> FindAsync(Expression<Func<T, bool>> expression);
        T Find(long id);
        Task<T> FindAsync(long id);
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        IQueryable<T> GetAll();
        #endregion Query

        int Insert(T entity);
        Task<int> InsertAsync(T entity);
        Task<int> InsertRangeAsync(List<T> entities);
        int Update(T entity, Expression<Func<T, object>>[] updatedProperties);
        Task<int> UpdateAsync(T entity, Expression<Func<T, object>>[] updatedProperties);
        Task<int> UpdateRangeAsync(List<T> entities, Expression<Func<T, object>>[] updatedProperties);
        int Delete(long id);
        Task<int> DeleteAsync(long id);
        Task<int> DeleteRangeAsync(List<T> entities);
        Task<int> DeleteRangeAsync(Expression<Func<T, bool>> expression);
        Task<int> DeleteRangeAsync(List<long> ids);
    }
}
