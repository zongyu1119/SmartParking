﻿using CacheManager.Core.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using zy.webcore.Share.Application.Utilitys;
using zy.webcore.Share.Constraint.Dtos.ResultModels;
using zy.webcore.Share.ZyEfcore;

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
            var user=context.HttpContext.User;
            if ((!user.Identity.IsAuthenticated)&&!context.Filters.Any(x=>x.GetType()==typeof(ZyAllowUnAuthorizationAttribute)))
            { 
                context.Result = new UnauthorizedObjectResult(new AppSrvResult(HttpStatusCode.Unauthorized,"未验证！"));   //根据实际业务定义返回结果，可以是OkObjectResult，也可以是其他（例如UnauthorizedObjectResult）
                //context.Result = new UnauthorizedObjectResult(responseModel);
            }
            if (user.Identity.IsAuthenticated)
            {
                var userContext = context.HttpContext.RequestServices.GetService<UserContext>();
                userContext.Id = long.Parse(user.Claims.FirstOrDefault(x => x.Type == "Id")?.Value);
                userContext.Account = user.Claims.FirstOrDefault(x => x.Type == "Account")?.Value;
                userContext.Name= user.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
                userContext.RoleIds = user.Claims.Where(x => x.Type == ClaimTypes.Role).Select(x => long.Parse(x.Value)).ToList();
            }
            if (_permissions != null)
            {

            }
            _logger.LogInformation("[Auth]"+_permissions??"");
        }
    }
}
