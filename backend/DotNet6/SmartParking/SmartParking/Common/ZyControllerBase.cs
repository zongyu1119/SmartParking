﻿using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace SmartParking.Common
{
    /// <summary>
    /// 自定义的控制器基础类
    /// </summary>
    public class ZyControllerBase : ControllerBase
    {
        protected  IConfiguration configuration;//配置
        protected ILogger<ZyControllerBase> logger;//日志
        public ZyControllerBase(IConfiguration _configuration, ILogger<ZyControllerBase> _logger)
        {
            configuration = _configuration;
            logger = _logger;
        }
        /// <summary>
        /// 获得登录用户ID
        /// </summary>
        public int? UserId
        {
            get
            {
                string id = HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("Id")).Value;
                if (int.TryParse(id, out int ID))
                {
                    return ID;
                }
                else { return null; }
            }
        }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            get
            {
                return HttpContext.User.Identity.Name;
            }
        }
        /// <summary>
        /// 登录用户的权限id
        /// </summary>
        public int? RoleId
        {
            get
            {
               string roleIdStr  = HttpContext.User.Claims.FirstOrDefault(x=>x.Type.Equals("RoleId")).Value;
                if(int.TryParse(roleIdStr, out int roleId))
                {
                    return roleId;
                }
                else { return null; }
            }
        }
        /// <summary>
        /// 租户号
        /// </summary>
        public int? TenantId
        {
            get
            {
                string roleIdStr = HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("TenantId")).Value;
                if (int.TryParse(roleIdStr, out int roleId))
                {
                    return roleId;
                }
                else { return null; }
            }
        }
    }
}
