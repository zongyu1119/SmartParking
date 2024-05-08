namespace Zy.User.Constraint.IServices
{
    /// <summary>
    /// 用户登录验证服务
    /// </summary>
   
    public interface ISessionService:IAppService
    {
        [AuditInterceptor("Session")]
        Task<ZyResult<JwtTokenResult>> SessionAsync(SessionDto loginDto, ClientTypeEnum clientType = ClientTypeEnum.PC);
    }
}
