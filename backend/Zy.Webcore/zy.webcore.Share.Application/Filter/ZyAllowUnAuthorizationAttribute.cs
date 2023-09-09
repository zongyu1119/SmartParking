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
