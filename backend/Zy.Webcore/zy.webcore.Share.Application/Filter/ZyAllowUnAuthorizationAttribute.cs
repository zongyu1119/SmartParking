using CacheManager.Core.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using zy.webcore.Share.Application.Utilitys;
using zy.webcore.Share.Constraint.Dtos.ResultModels;
using zy.webcore.Share.ZyEfcore;

namespace zy.webcore.Share.Application.Filter
{
    /// <summary>
    /// 不需要鉴权的
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    public class ZyAllowUnAuthorizationAttribute : Attribute, IAuthorizationFilter
    {
        private readonly ILogger<ZyAllowUnAuthorizationAttribute> _logger;
        public ZyAllowUnAuthorizationAttribute()
        {
            _logger = ServiceLocator.Instance.GetService<ILogger<ZyAllowUnAuthorizationAttribute>>();
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {         
            _logger.LogInformation("[NoAuth]"+context.HttpContext.Request.Path??"");
        }
    }
}
