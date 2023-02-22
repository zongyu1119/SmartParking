using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;
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
                var httpContext = InfraHelper.Accessor.GetCurrentHttpContext();
                if (httpContext is not null)
                    return httpContext.RequestServices.GetRequiredService<IObjectMapper>();
                if (ServiceLocator.Provider is not null)
                    return ServiceLocator.Provider.GetService<IObjectMapper>();
                throw new NotImplementedException();
            }
        }

        protected AppSrvResult AppSrvResult() => new();

        protected AppSrvResult<TValue> AppSrvResult<TValue>([NotNull] TValue value) => new(value);

        protected AppSrvResult Problem(HttpStatusCode statusCode, string detail) => new(statusCode, detail);

        protected Expression<Func<TEntity, object>>[] UpdatingProps<TEntity>(params Expression<Func<TEntity, object>>[] expressions) => expressions;
    }
}
