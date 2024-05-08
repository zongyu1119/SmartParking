using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Zy.Shared.ServicesLocator;

namespace Zy.Shared.WebApi.Authorizes
{
    /// <summary>
    /// 不需要鉴权的
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    public class ZyAllowUnAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly ILogger<ZyAllowUnAuthorizeAttribute> _logger;
        public ZyAllowUnAuthorizeAttribute()
        {
            _logger = ServiceLocator.Instance.GetService<ILogger<ZyAllowUnAuthorizeAttribute>>();
        }

        public bool AllowMultiple => throw new NotImplementedException();


        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _logger.LogInformation("[NoAuth]" + context.HttpContext.Request.Path ?? "");
        }
    }
}
