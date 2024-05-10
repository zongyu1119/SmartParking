using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zy.User.Constraint.IServices
{
    /// <summary>
    /// 用户表增、删、改服务接口
    /// </summary>
    public interface ISysUserService : IAppService
    {
        /// <summary>
        /// 新增用户表
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [AuditInterceptor("新增用户表")]
        Task<ZyResult<bool>> AddAsync(SysUserInputDto dto);
        /// <summary>
        /// 用户表修改
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [AuditInterceptor("修改用户表")]
        Task<ZyResult<bool>> UpdateAsync(long id, SysUserInputDto dto);
        /// <summary>
        /// 批量导入用户表
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        //[AuditInterceptor("批量导入用户表")]
        //[UnitOfWork]
        //Task<ZyResult<bool>> BatchSaveAsync(List<SysUserImportDto> dtos);
        /// <summary>
        /// 删除用户表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AuditInterceptor("删除用户表")]
        Task<ZyResult<bool>> DeleteAsync(long id);
        /// <summary>
        /// 批量删除用户表
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [AuditInterceptor("批量删除用户表")]
        Task<ZyResult<bool>> DeleteRangeAsync(List<long> ids);
    }
}
