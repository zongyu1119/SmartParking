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
        public async void OnAuthorization(AuthorizationFilterContext context)
        {          
            var user=context.HttpContext.User;
            if ((!user.Identity.IsAuthenticated)&&!context.Filters.Any(x=>x.GetType()==typeof(ZyAllowUnAuthorizationAttribute)))
            { 
                context.Result = new UnauthorizedObjectResult(new AppSrvResult(HttpStatusCode.Unauthorized,"未验证！"));   //根据实际业务定义返回结果，可以是OkObjectResult，也可以是其他（例如UnauthorizedObjectResult）
                //context.Result = new UnauthorizedObjectResult(responseModel);
            }
            if (user.Identity.IsAuthenticated&& !context.Filters.Any(x => x.GetType() == typeof(ZyAllowUnAuthorizationAttribute)))
            {
                try
                {
                    var userContext = context.HttpContext.RequestServices.GetService<UserContext>();
                    userContext.Id = long.Parse(user.Claims.FirstOrDefault(x => x.Type == "Id")?.Value);
                    userContext.Account = user.Claims.FirstOrDefault(x => x.Type == "Account")?.Value;
                    userContext.Name = user.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
                    userContext.RoleIds = user.Claims.Where(x => x.Type == ClaimTypes.Role).Select(x => long.Parse(x.Value)).ToList();
                    userContext.ClientType = (ClientTypeEnum)int.Parse(user.Claims.FirstOrDefault(x => x.Type == "ClientType")?.Value);
                    userContext.Email = user.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
                    var cacheService = context.HttpContext.RequestServices.GetService<ICacheService>();
                    var cacheKey = CacheKeyConsts.userLoginObjCacheKeyPrefix + ":" + userContext.ClientType.GetDescription() + ":" + user.Claims.FirstOrDefault(x => x.Type == "Id")?.Value;
                    var userInfo = await cacheService.GetAsync<UserInfo>(cacheKey);
                    if (userInfo == null)
                    {
                        context.Result = new UnauthorizedObjectResult(new AppSrvResult(HttpStatusCode.Unauthorized, "用户未登录！"));   //根据实际业务定义返回结果，可以是OkObjectResult，也可以是其他（例如UnauthorizedObjectResult）
                    }
                    else
                    if (_permissions != null)
                    {
                        if (!userInfo.MenuCodeList.Contains(_permissions))
                            context.Result = new UnauthorizedObjectResult(new AppSrvResult(HttpStatusCode.Unauthorized, "无权操作！"));   //根据实际业务定义返回结果，可以是OkObjectResult，也可以是其他（例如UnauthorizedObjectResult）
                    }
                }
                catch(Exception ex) {
                    context.Result = new UnauthorizedObjectResult(new AppSrvResult(HttpStatusCode.Unauthorized, "用户未登录！"));  
                    _logger.LogInformation("[Auth]Error" + ex.Message ?? "");
                }
            }
            _logger.LogInformation("[Auth]"+_permissions??"");
        }
    }
}
