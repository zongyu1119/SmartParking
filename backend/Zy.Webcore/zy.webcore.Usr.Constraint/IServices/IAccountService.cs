﻿using zy.webcore.Share.Constraint.Dtos.ResultModels;
using zy.webcore.Share.Constraint.IService;
using zy.webcore.Usr.Constraint.Dtos.Account;

namespace zy.webcore.Usr.WebApi.Authorize
{
    /// <summary>
    /// 用户验证相关接口
    /// </summary>
    public interface IAccountService: IAppService
    {
        /// <summary>
        /// 获得JWTBear
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<AppSrvResult<LoginResDto>> GetJWTBearAsync(AccountLoginDto user);
    }
}