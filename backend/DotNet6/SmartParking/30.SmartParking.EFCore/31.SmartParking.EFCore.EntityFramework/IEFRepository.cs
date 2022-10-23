using SmartParking.EFCore.EntityFramework.Entities;
using System.Linq.Expressions;

/// <summary>
///  Namespace: Service.Comm
///  Name： IRepository
///  Author: zy
///  Time:  2022-04-02 23:21:56
///  Version:  0.1
/// </summary>

namespace SmartParking.EFCore.EntityFramework
{
    /// <summary>
    /// 存储库
    /// </summary>
    public interface IEFRepository<TEntity> where TEntity : IEntity, new()
    {
       
        /// <summary>
        /// DbContext对象
        /// </summary>
        DbContext Context { get; }
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


        //
        // 摘要:
        //     返回IQueryable
        //
        // 参数:
        //   writeDb:
        //     是否读写库，默认false,可选参数
        //
        //   noTracking:
        //     是否开启跟踪，默认false,可选参数
        IQueryable<TEntity> GetAll(bool writeDb = false, bool noTracking = true);

        IQueryable<TrdEntity> GetAll<TrdEntity>(bool writeDb = false, bool noTracking = true) where TrdEntity : Entity;

        //
        // 摘要:
        //     根据Id查询,返回单个实体
        //
        // 参数:
        //   keyValue:
        //     Id
        //
        //   navigationPropertyPath:
        //     导航属性,可选参数
        //
        //   writeDb:
        //     是否读写库,默认false，可选参数
        //
        //   noTracking:
        //     是否开启跟踪，默认不开启，可选参数
        //
        //   cancellationToken:
        //     System.Threading.CancellationToken
        //
        // 返回结果:
        //     TEntity
        Task<TEntity?> FindAsync(long keyValue, Expression<Func<TEntity, dynamic>> navigationPropertyPath = null, bool writeDb = false, bool noTracking = true, CancellationToken cancellationToken = default(CancellationToken));

        //
        // 摘要:
        //     根据条件查询,返回单个实体
        //
        // 参数:
        //   whereExpression:
        //     查询条件
        //
        //   navigationPropertyPath:
        //     导航属性,可选参数
        //
        //   orderByExpression:
        //     排序字段，默认主键，可选参数
        //
        //   ascending:
        //     排序方式，默认逆序，可选参数
        //
        //   writeDb:
        //     是否读写库,默认false，可选参数
        //
        //   noTracking:
        //     是否开启跟踪，默认不开启，可选参数
        //
        //   cancellationToken:
        //     System.Threading.CancellationToken
        Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, dynamic>> navigationPropertyPath = null, Expression<Func<TEntity, object>> orderByExpression = null, bool ascending = false, bool writeDb = false, bool noTracking = true, CancellationToken cancellationToken = default(CancellationToken));

        //
        // 摘要:
        //     根据条件查询,返回单个实体或对象
        //
        // 参数:
        //   selector:
        //     选择器
        //
        //   whereExpression:
        //     查询条件
        //
        //   orderByExpression:
        //     排序字段，默认主键，可选参数
        //
        //   ascending:
        //     排序方式，默认逆序，可选参数
        //
        //   writeDb:
        //     是否读写库,默认false，可选参数
        //
        //   noTracking:
        //     是否开启跟踪，默认不开启，可选参数
        //
        //   cancellationToken:
        //     System.Threading.CancellationToken
        //
        // 类型参数:
        //   TResult:
        //     匿名对象
        Task<TResult?> FetchAsync<TResult>(Expression<Func<TEntity, TResult>> selector, Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, object>> orderByExpression = null, bool ascending = false, bool writeDb = false, bool noTracking = true, CancellationToken cancellationToken = default(CancellationToken));

        //
        // 摘要:
        //     更新单个实体
        //
        // 参数:
        //   entity:
        //     entity
        //
        //   updatingExpressions:
        //     需要更新列的表达式树数组
        //
        //   cancellationToken:
        //     System.Threading.CancellationToken
        Task<int> UpdateAsync(TEntity entity, Expression<Func<TEntity, object>>[] updatingExpressions, CancellationToken cancellationToken = default(CancellationToken));

        //
        // 摘要:
        //     批量更新
        //
        // 参数:
        //   whereExpression:
        //     查询条件
        //
        //   updatingExpression:
        //     需要更新的字段
        //
        //   cancellationToken:
        //     System.Threading.CancellationToken
        Task<int> UpdateRangeAsync(Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, TEntity>> updatingExpression, CancellationToken cancellationToken = default(CancellationToken));

        Task<int> UpdateRangeAsync(Dictionary<long, List<(string propertyName, dynamic propertyValue)>> propertyNameAndValues, CancellationToken cancellationToken = default(CancellationToken));

        //
        // 摘要:
        //     删除实体
        //
        // 参数:
        //   keyValue:
        //     Id
        //
        //   cancellationToken:
        //     System.Threading.CancellationToken
        Task<int> DeleteAsync(long keyValue, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="whereExpression">查询条件</param>
        /// <param name="isForceDel">强制删除</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> DeleteRangeAsync(Expression<Func<TEntity, bool>> whereExpression, bool isForceDel = false, CancellationToken cancellationToken = default(CancellationToken));
    }
}
