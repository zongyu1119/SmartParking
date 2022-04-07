using Microsoft.AspNetCore.Mvc.Filters;
using Common.ObjExt;

namespace SmartParking.Common
{
    /// <summary>
    /// 审计过滤器
    /// </summary>
    public class AuditFilterAttribute : Attribute, IResourceFilter
    {
        ILogger<AuditFilterAttribute> logger;
        /// <summary>
        /// 审计过滤器
        /// </summary>
        /// <param name="_logger"></param>
        public AuditFilterAttribute(ILogger<AuditFilterAttribute> _logger)
        {
            logger = _logger;
        }
        /// <summary>
        /// 请求成功后
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            logger?.LogInformation("[Audit]"+ context.HttpContext.Request.Path.ToString() +" "+ context.Result.GetType().GetProperty("Value").GetValue(context.Result).ToJson());
        }
        /// <summary>
        /// 请求之前
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            logger.LogInformation("[Audit]" + context.HttpContext.Request.Path.ToString());
            // context.Result = obj; //设置该Result将是filter管道短路，阻止执行管道的其他阶段
        }
    }
}
