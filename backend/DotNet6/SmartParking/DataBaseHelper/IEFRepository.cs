using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

/// <summary>
///  Namespace: Service.Comm
///  Name： IRepository
///  Author: zy
///  Time:  2022-04-02 23:21:56
///  Version:  0.1
/// </summary>

namespace DataBaseHelper
{
    /// <summary>
    /// 存储库
    /// </summary>
    public interface IEFRepository<TEntity>
    {
      /// <summary>
      /// 新增
      /// </summary>
      /// <param name="entity"></param>
      /// <param name="cancellationToken"></param>
      /// <returns></returns>
        Task<int> InsertAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));

      /// <summary>
      /// 修改
      /// </summary>
      /// <param name="entities"></param>
      /// <param name="cancellationToken"></param>
      /// <returns></returns>
        Task<int> InsertRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken));

       /// <summary>
       /// 修改
       /// </summary>
       /// <param name="entity"></param>
       /// <param name="cancellationToken"></param>
       /// <returns></returns>
        Task<int> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <param name="writeDb"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> whereExpression, bool writeDb = false, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// 数量
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <param name="writeDb"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> CountAsync(Expression<Func<TEntity, bool>> whereExpression, bool writeDb = false, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 根据条件查询，返回IQueryable
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="writeDb">是否读写库，默认false,可选参数</param>
        /// <param name="noTracking"> 是否开启跟踪，默认false,可选参数</param>
        /// <returns></returns>
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression, bool writeDb = false, bool noTracking = true);
    }
}
