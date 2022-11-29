using Microsoft.AspNetCore.Http;
using SmartParking.Share.Core;

namespace SmartParking.Server.WebApi.Middleware
{
    public class UserVerificationMiddleware
    {
        private readonly RequestDelegate _next;
        //private IHttpContextAccessor _httpContextAccessor;
        /// <summary>
        /// 用户认证中间件
        /// </summary>
        /// <param name="next"></param>
        public UserVerificationMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            //var userContext= _httpContextAccessor.HttpContext.RequestServices.GetService<UserContext>();
            var userContext = httpContext.RequestServices.GetService<UserContext>();
            userContext.Id = long.Parse(httpContext.User.Claims.FirstOrDefault(x => x.Type == "id")?.Value??"0");
            if(userContext.Id == 0)
            {
                await httpContext.Response.WriteAsync(text: "用户ID为空，用户登录验证不通过！\r\n");
                return;
            }
            await _next(httpContext);
        }
    }
}
