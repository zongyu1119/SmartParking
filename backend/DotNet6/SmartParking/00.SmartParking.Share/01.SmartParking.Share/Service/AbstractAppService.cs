using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Net;
using Microsoft.AspNetCore.Http;
using SmartParking.Share.Infra;
using Microsoft.Extensions.DependencyInjection;
using SmartParking.Share.Core;
using SmartParking.Share.Contracts;
namespace SmartParking.Share.Service
{
    public abstract class AbstractAppService
    {
        public IObjectMapper Mapper
        {
            get
            {
                HttpContext currentHttpContext = InfraHelper.Accessor.GetCurrentHttpContext();
                if (currentHttpContext != null)
                {
                    return currentHttpContext.RequestServices.GetRequiredService<IObjectMapper>();
                }

                if (ServiceLocator.Provider != null)
                {
                    return ServiceLocator.Provider.GetService<IObjectMapper>();
                }

                throw new NotImplementedException();
            }
        }

        protected AppSrvResult AppSrvResult()
        {
            return new AppSrvResult();
        }

        protected AppSrvResult<TValue> AppSrvResult<TValue>([NotNull] TValue value)
        {
            return new AppSrvResult<TValue>(value);
        }

        protected ProblemDetails Problem(HttpStatusCode? statusCode = null, string detail = null, string title = null, string instance = null, string type = null)
        {
            return new ProblemDetails(statusCode, detail, title, instance, type);
        }

        protected Expression<Func<TEntity, object>>[] UpdatingProps<TEntity>(params Expression<Func<TEntity, object>>[] expressions)
        {
            return expressions;
        }
    }
}
