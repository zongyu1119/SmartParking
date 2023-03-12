

namespace zy.webcore.Share.Application.Service
{
    public abstract class AbstractAppService : IAppService
    {
      
        public IObjectMapper Mapper
        {
            get
            {
                var httpContext = HttpContextUtility.GetCurrentHttpContext();
                if (httpContext is not null)
                    return httpContext.RequestServices.GetRequiredService<IObjectMapper>();
                if (ServiceLocator.Instance is not null)
                    return ServiceLocator.Instance.GetService<IObjectMapper>();
                throw new NotImplementedException();
            }
        }
        public static ZyIdGenerator IdGenerator => ServiceLocator.Instance.GetService<ZyIdGenerator>() ?? new ZyIdGenerator();
        protected AppSrvResult AppSrvResult() => new();
        protected AppSrvResult Problem(HttpStatusCode statusCode, string detail) => new(statusCode, detail);
        protected AppSrvResult<T> Problem<T>(HttpStatusCode statusCode, string detail) => new(statusCode, detail);
        protected Expression<Func<TEntity, object>>[] UpdatingProps<TEntity>(params Expression<Func<TEntity, object>>[] expressions) => expressions;
    }
}
