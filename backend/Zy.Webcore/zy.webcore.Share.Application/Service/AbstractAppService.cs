using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using zy.webcore.Share.Application.Utilitys;
using zy.webcore.Share.Constraint.Core.Mapper;
using zy.webcore.Share.Constraint.Dtos.ResultModels;
using zy.webcore.Share.Constraint.IService;

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
        public static IdGeneratorHelper IdGenerator => ServiceLocator.Instance.GetService<IdGeneratorHelper>() ?? new IdGeneratorHelper();
        protected AppSrvResult AppSrvResult() => new();
        protected AppSrvResult Problem(HttpStatusCode statusCode, string detail) => new(statusCode, detail);
        protected AppSrvResult<T> Problem<T>(HttpStatusCode statusCode, string detail) => new(statusCode, detail);
        protected Expression<Func<TEntity, object>>[] UpdatingProps<TEntity>(params Expression<Func<TEntity, object>>[] expressions) => expressions;
    }
}
