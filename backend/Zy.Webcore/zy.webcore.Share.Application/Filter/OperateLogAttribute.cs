using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zy.webcore.Share.Application.Filter
{
    public class OperateLogAttribute:Attribute, IResourceFilter
    {
        private readonly ILogger<OperateLogAttribute> _logger;
        /// <summary>
        /// 审计过滤器
        /// </summary>
        /// <param name="_logger"></param>
        /// <param name="_service"></param>
        public OperateLogAttribute(ILogger<OperateLogAttribute> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// 请求成功后
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            var TenantId = context.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("TenantId"));
            var userId = context.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("Id"));
            if (TenantId != null && userId != null)
            {
             
            }
            _logger?.LogInformation("[Audit]" + context.HttpContext.Request.Path.ToString());

        }
        /// <summary>
        /// 请求之前
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            var TenantId = context.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("TenantId"));
            var userId = context.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("Id"));
            if (TenantId != null && userId != null)
            {
               
            }
            _logger.LogInformation("[Audit]" + context.HttpContext.Request.Path.ToString());
            // context.Result = obj; //设置该Result将是filter管道短路，阻止执行管道的其他阶段
        }

    }
}
