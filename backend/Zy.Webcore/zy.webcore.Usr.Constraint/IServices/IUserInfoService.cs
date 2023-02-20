﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zy.webcore.Share.Constraint.IService;
using zy.webcore.Usr.Constraint.Dtos.Account;

namespace zy.webcore.Usr.Constraint.IServices
{
    /// <summary>
    /// 用户服务
    /// </summary>
    public interface IUserInfoService:IAppService
    {
        /// <summary>
        /// 获得用户详细信息
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        Task<UserDetailInfoDto> GetUserDetailInfoAsync(string account); 
    }
}
