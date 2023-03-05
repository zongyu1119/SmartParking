using CacheManager.Core.Logging;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zy.webcore.Share.Application.Utilitys;

namespace zy.webcore.Share.Application.Filter
{
    /// <summary>
    /// 鉴权
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    public class ZyAuthorizationAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string _permissions;
        private readonly ILogger<ZyAuthorizationAttribute> _logger;
        public ZyAuthorizationAttribute(string permissions=null)
        {
            _permissions = permissions;
            _logger = ServiceLocator.Instance.GetService<ILogger<ZyAuthorizationAttribute>>();
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _logger.LogInformation("[Auth]"+_permissions??"");
        }
    }
}
