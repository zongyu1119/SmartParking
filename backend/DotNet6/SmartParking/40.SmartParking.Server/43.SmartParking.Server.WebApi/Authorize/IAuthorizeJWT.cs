using SmartParking.Server.Const.Dtos.DtoBase;
using SmartParking.Server.Const.Dtos.User;

namespace SmartParking.Authorize
{
    /// <summary>
    /// 用户验证相关接口
    /// </summary>
    public interface IAuthorizeJWT
    {
        /// <summary>
        /// 获得JWTBear
        /// </summary>
        /// <param name="user"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ResDto<(string bear, UserDetailOutputDto user)>> GetJWTBear(ViewModels.UserLoginArgs user);
    }
}
