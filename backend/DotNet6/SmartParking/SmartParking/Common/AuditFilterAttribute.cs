using Microsoft.AspNetCore.Mvc.Filters;
using Common.ObjExt;
using DataBaseHelper;
using Service.IService;
using Service.Models;
using Service.Comm;
using Service.Params;

namespace SmartParking.Common
{
    /// <summary>
    /// 审计过滤器
    /// </summary>
    public class AuditFilterAttribute : Attribute, IResourceFilter
    {
        ILogger<AuditFilterAttribute> logger;
        IAuditService service;
        /// <summary>
        /// 审计过滤器
        /// </summary>
        /// <param name="_logger"></param>
        /// <param name="_repository"></param>
        public AuditFilterAttribute(ILogger<AuditFilterAttribute> _logger, IAuditService _service)
        {
            logger = _logger;
            service = _service;
        }
        /// <summary>
        /// 请求成功后
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            var TenantId= context.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("TenantId"));
            var userId = context.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("Id"));
            if (TenantId != null && userId != null)
            {
                service.Add(new AuditAddParam()
                {
                    ActionNmae = context.HttpContext.Request.Path.ToString(),
                    CreatedBy = int.Parse(userId.Value),
                    TenantId = int.Parse(TenantId.Value),
                    Description = context.HttpContext.Request.Path.ToString(),
                    Type = "Requested"

                });
            }
            logger?.LogInformation("[Audit]"+ context.HttpContext.Request.Path.ToString() +" "+ context.Result.GetType().GetProperty("Value").GetValue(context.Result).ToJson());

        }
        /// <summary>
        /// 请求之前
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void OnResourceExecuting(ResourceExecutingContext context)
        {           
            var TenantId = context.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("TenantId"));
            var userId =context.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("Id"));
            if (TenantId != null && userId != null)
            {
                service.Add(new AuditAddParam()
                {
                    ActionNmae = context.HttpContext.Request.Path.ToString(),
                    CreatedBy = int.Parse(userId.Value),
                    TenantId = int.Parse(TenantId.Value),
                    Description = context.HttpContext.Request.Path.ToString(),
                    Type = "Requesting"

                });
            }
            logger.LogInformation("[Audit]" + context.HttpContext.Request.Path.ToString());
            // context.Result = obj; //设置该Result将是filter管道短路，阻止执行管道的其他阶段
        }
    }
}
