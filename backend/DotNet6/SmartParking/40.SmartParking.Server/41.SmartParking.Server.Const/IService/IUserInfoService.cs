
using SmartParking.Server.Const.Dtos.User;
/// <summary>
///  Namespace: Service.IService
///  Name： IUserInfoService
///  Author: zy
///  Time:  2022-03-31 22:53:21
///  Version:  0.1
/// </summary>
namespace SmartParking.Server.Const.IService
{
    /// <summary>
    /// 用户信息服务接口
    /// </summary>
    public interface IUserInfoService
    {
        /// <summary>
        /// 获得用户详情-带权限角色的
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns></returns>
        Task<ResDto<UserDetailOutputDto>> GetUserDetailInfoAsync(long id);
        /// <summary>
        /// 使用用户名查询用户详情
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        Task<ResDto<UserDetailOutputDto>> GetUserDetailInfoAsync(string userName);
        /// <summary>
        /// 前端需要的用户详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ResDto<UserDetailOutputDto>> GetUserDetailInfoToViewAsync(long id);
        /// <summary>
        /// 获得用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ResDto<UserOutputDto>> GetModelAsync(long id);
        /// <summary>
        /// 获得用户列表
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<ResDto<List<UserOutputDto>>> GetListAsync(UserPageSearchDto dto);
        /// <summary>
        /// 获得分页用户列表
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<ResPageDto<UserOutputDto>> GetPageListAsync(UserPageSearchDto dto);
        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<ResDto<bool>> CreateAsync(UserCreateDto dto);
        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ResDto<bool>> UpdateAsync(UserUpdateDto dto,long id);
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ResDto<bool>> DeleteAsync(long id);
        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="pwd"></param>
        /// <returns></returns>
        Task<ResDto<bool>> UpdatePwdAsync(string pwd);
    }
}
