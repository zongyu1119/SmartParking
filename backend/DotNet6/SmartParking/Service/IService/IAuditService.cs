
/// <summary>
///  Namespace: Service.IService
///  Name： IAuditService
///  Author: zy
///  Time:  2022-04-13 22:26:30
///  Version:  0.1
/// </summary>

namespace Service.IService
{
    /// <summary>
    /// 审计相关Service
    /// </summary>
    public interface IAuditService
    {
        /// <summary>
        /// 获得模型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Res<AuditModel>> GetModel(long Id);
        /// <summary>
        /// 获得列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public Task<Res<List<AuditModel>>> GetList(AuditQueryParam param);
        /// <summary>
        /// 获得分页列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public Task<ResPage<AuditModel>> GetList(ParamPage<AuditQueryParam> param);
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public Task<Res<bool>> Add(AuditAddParam param);

    }
}
