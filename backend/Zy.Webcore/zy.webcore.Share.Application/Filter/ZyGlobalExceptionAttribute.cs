using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using zy.webcore.Share.Application.Utilitys;
using zy.webcore.Share.Constraint.Dtos.ResultModels;

namespace zy.webcore.Share.Application.Filter
{
    /// <summary>
    /// 全局异常处理过滤器
    /// </summary>
    [AttributeUsage(AttributeTargets.All,Inherited =true)]
    public class ZyGlobalExceptionAttribute : Attribute, IExceptionFilter
    {
        private readonly ILogger<ZyGlobalExceptionAttribute> _logger;
        public ZyGlobalExceptionAttribute()
        {
            _logger = ServiceLocator.Instance.GetService<ILogger<ZyGlobalExceptionAttribute>>();
        }
        public void OnException(ExceptionContext context)
        {
            var res= new ObjectResult(new AppSrvResult(System.Net.HttpStatusCode.InternalServerError, context.Exception.Message));
            res.StatusCode = 500;
            context.Result = res;
            _logger.LogError("[Error]" + context.Exception.Message ?? "");
        }
    }
}
