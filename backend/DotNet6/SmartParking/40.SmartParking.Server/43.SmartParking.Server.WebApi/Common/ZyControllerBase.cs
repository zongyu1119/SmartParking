using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace SmartParking.Common
{
    /// <summary>
    /// 自定义的控制器基础类
    /// </summary>
    [EnableCors("Cors")]//配置Cors,允许跨域
    public class ZyControllerBase : ControllerBase
    {
        /// <summary>
        /// 配置
        /// </summary>
        protected  IConfiguration configuration;//配置
        /// <summary>
        /// 日志
        /// </summary>
        protected ILogger<ZyControllerBase> logger;//日志
        /// <summary>
        /// 控制器基础类
        /// </summary>
        /// <param name="_configuration"></param>
        /// <param name="_logger"></param>
        public ZyControllerBase(IConfiguration _configuration, ILogger<ZyControllerBase> _logger)
        {
            configuration = _configuration;
            logger = _logger;
        }
        /// <summary>
        /// 当前用户的Id
        /// </summary>
        public long? UserId
        {
            get
            {
                var x= HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("Id")).Value;
                //2022-04-20修改为使用Session获取信息，需要在登录时将Session记住
                //string id = HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("Id")).Value;
                return HttpContext.Session.GetInt32("UserId");
            }
            set
            {
                if (value != null)
                    HttpContext.Session.SetInt32("UserId", (int)value);
                else
                    HttpContext.Session.Remove("UserId");
            }
        }
        /// <summary>
        /// 用户名
        /// </summary>
        public string? UserName
        {
            get
            {
                return HttpContext.Session.GetString("UserName");
            }
            set
            {
                if (value != null)
                    HttpContext.Session.SetString("UserName", (string)value);
                else
                    HttpContext.Session.Remove("UserName");
            }
        }
        /// <summary>
        /// 登录用户的权限id
        /// </summary>
        public int? RoleId
        {
            get
            {
                return HttpContext.Session.GetInt32("RoleId");
            }
            set
            {
                if (value != null)
                    HttpContext.Session.SetInt32("RoleId", (int)value);
                else
                    HttpContext.Session.Remove("RoleId");
            }
        }
        /// <summary>
        /// 租户号
        /// </summary>
        public long? TenantId
        {
            get
            {
                return HttpContext.Session.GetInt32("TenantId");
            }
            set
            {
                if (value != null)
                    HttpContext.Session.SetInt32("TenantId", (int)value);
                else
                    HttpContext.Session.Remove("TenantId");
            }
        }
    }
}
