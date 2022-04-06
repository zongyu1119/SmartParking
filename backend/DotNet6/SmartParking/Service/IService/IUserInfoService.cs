using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Models;
using Service.Comm;
using Service.Params;
using Autofac.Extras.DynamicProxy;
/// <summary>
///  Namespace: Service.IService
///  Name： IUserInfoService
///  Author: zy
///  Time:  2022-03-31 22:53:21
///  Version:  0.1
/// </summary>

namespace Service.IService
{
    /// <summary>
    /// 用户信息服务接口
    /// </summary>
    [Intercept(typeof(Comm.ServiceInterceptor))]
    public interface IUserInfoService
    {
        /// <summary>
        /// 获得用户详情-带权限角色的
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns></returns>
        public UserDetailInfoModel? GetUserDetailInfo(int id);
        /// <summary>
        /// 使用用户名查询用户详情
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        public UserDetailInfoModel? GetUserDetailInfo(string userName);
        /// <summary>
        /// 前端需要的用户详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Res<UserDetailInfoModel> GetUserDetailInfoToView(int id);
        /// <summary>
        /// 获得用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Res<UserInfo> GetUserInfo(int id);
        /// <summary>
        /// 获得用户列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public Res<List<UserInfo>> GetUserInfoList(UserInfoQueryParam param);
        /// <summary>
        /// 获得分页用户列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ResPage<UserInfo> GetUserInfoList(ParamPage<UserInfoQueryParam> param);
        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public Res<bool> AddUserInfo(UserInfoAddParam param);
        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public Res<bool> UpdateUserInfo(UserInfoUpdateParam param);
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Res<bool> DeleteUserInfo(int id);
        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public Res<bool> UpdateUserInfoPassword(UserInfoUpdatePasswordParam param);
    }
}
