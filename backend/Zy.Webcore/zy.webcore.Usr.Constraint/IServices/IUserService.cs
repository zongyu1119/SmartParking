using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zy.webcore.Share.Application.Filter;
using zy.webcore.Share.Constraint.Dtos.ResultModels;
using zy.webcore.Share.Constraint.IService;
using zy.webcore.Usr.Constraint.Dtos.Account;
using zy.webcore.Usr.Constraint.Dtos.User;

namespace zy.webcore.Usr.Constraint.IServices
{
    /// <summary>
    /// 用户服务
    /// </summary>
   
    public interface IUserService:IAppService
    {
        /// <summary>
        /// 获得用户详细信息
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        Task<UserDetailInfoDto> GetUserDetailInfoAsync(string account);
        /// <summary>
        /// 查询用户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<AppSrvResult<List<UserOutputDto>>> GetListAsync(UserSearchDto dto);
        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<AppSrvResult<bool>> AddAsync(UserInputDto dto);
        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<AppSrvResult<object>> GetCacheAsync(string key);
        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        Task<AppSrvResult<bool>> SetCacheAsync(string key,string value);
    }
}
