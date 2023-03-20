using zy.webcore.Share.Constraint.Dtos.ResultModels;
using zy.webcore.Share.Constraint.IService;

namespace zy.webcore.Usr.WebApi.Authorize
{
    /// <summary>
    /// 用户验证相关接口
    /// </summary>
    public interface IAccountService: IAppService
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="user"></param>
        /// <param name="clientType"></param>
        /// <returns></returns>
        Task<AppSrvResult<LoginResDto>> LoginAsync(AccountLoginDto user, ClientTypeEnum clientType = ClientTypeEnum.PC);
        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <returns></returns>
        Task<AppSrvResult<CaptchOutputDto>> GetCaptchAsync();
        /// <summary>
        /// 获取验证信息
        /// </summary>
        /// <returns></returns>
        Task<AppSrvResult<UserDetailInfoDto>> GetVerifyInfoAsync();
    }
}
