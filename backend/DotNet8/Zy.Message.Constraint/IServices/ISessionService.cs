using Zy.Message.Constraint.Dtos;
using Zy.Shared.Constraint.Dtos;
using Zy.Shared.Constraint.IServices;
using Zy.Shared.Enums;
namespace Zy.Message.Constraint.IServices
{
    /// <summary>
    /// 用户登录验证服务
    /// </summary>
    public interface ISessionService:IAppService
    {
        Task<ZyResult<JwtTokenResult>> SessionAsync(LoginDto loginDto, ClientTypeEnum clientType = ClientTypeEnum.PC);
    }
}
