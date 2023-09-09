namespace zy.webcore.Share.Application.Filter
{
    [AttributeUsage(AttributeTargets.All)]
    public class ZyResourceAttribute:Attribute, IResourceFilter
    {
        private readonly ILogger<ZyResourceAttribute> _logger;
        /// <summary>
        /// 审计过滤器
        /// </summary>
        /// <param name="_logger"></param>
        /// <param name="_service"></param>
        public ZyResourceAttribute()
        {
            _logger = ServiceLocator.Instance.GetService<ILogger<ZyResourceAttribute>>();
        }
        /// <summary>
        /// 请求成功后
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void OnResourceExecuted(ResourceExecutedContext context)
        {           
            _logger?.LogInformation("[OnResourceExecuted]" + context.HttpContext.Request.Path.ToString());
        }
        /// <summary>
        /// 请求之前
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void OnResourceExecuting(ResourceExecutingContext context)
        {          
            _logger.LogInformation("[OnResourceExecuting]" + context.HttpContext.Request.Path.ToString());
            // context.Result = obj; //设置该Result将是filter管道短路，阻止执行管道的其他阶段
        }
    }
}
