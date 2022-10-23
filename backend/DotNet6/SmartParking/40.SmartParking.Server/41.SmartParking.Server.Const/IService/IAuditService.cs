/// <summary>
///  Namespace: Service.IService
///  Name： IAuditService
///  Author: zy
///  Time:  2022-04-13 22:26:30
///  Version:  0.1
/// </summary>
namespace SmartParking.Server.Const.IService
{
    /// <summary>
    /// 审计相关Service
    /// </summary>
    public interface IAuditService
    {
        /// <summary>
        /// 获得模型
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<ResDto<AuditOutputDto>> GetModelAsync(long Id);
        /// <summary>
        /// 获得列表
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<ResDto<List<AuditOutputDto>>> GetListAsync(AuditPageSearchDto dto);
        /// <summary>
        /// 获得分页列表
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<ResPageDto<AuditOutputDto>> GetPageListAsync(AuditPageSearchDto dto);
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<ResDto<bool>> CreateAsync(AuditCreateDto dto);

    }
}
