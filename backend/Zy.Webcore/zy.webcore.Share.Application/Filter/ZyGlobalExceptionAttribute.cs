
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
            context.Result = new ObjectResult(new AppSrvResult(System.Net.HttpStatusCode.InternalServerError, context.Exception.Message))
            {
                StatusCode = 500
            };
            _logger.LogError("[Error]" + context.Exception.Message ?? "");
        }
    }
}
