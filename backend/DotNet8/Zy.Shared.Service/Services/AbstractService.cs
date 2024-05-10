using AutoMapper;
using AutoMapper.Internal.Mappers;
using System.Linq.Expressions;
using System.Net;
using Zy.Shared.Constraint.Dtos;
using Zy.Shared.Service.Utility;
using Zy.Shared.ServicesLocator;
using Zy.Shared.YitterHelper.Services;

namespace Zy.Shared.Service.Services
{
    public  class AbstractService
    {
        public IMapper Mapper
        {
            get
            {
                var httpContext = HttpContextUtility.GetCurrentHttpContext();
                if (httpContext is not null)
                    return (IMapper)httpContext.RequestServices.GetService(typeof(IMapper));
                if (ServiceLocator.Instance is not null)
                    return (IMapper)ServiceLocator.Instance.GetService(typeof(IMapper));
                throw new NotImplementedException();
            }
        }
        public static ZyIdGenerator IdGenerator => (ZyIdGenerator)ServiceLocator.Instance.GetService(typeof(ZyIdGenerator));
        protected ZyResult ZyResult() => new();
        protected ZyResult Problem(HttpStatusCode statusCode, string detail) => new(statusCode, detail);
        protected ZyResult<T> Problem<T>(HttpStatusCode statusCode, string detail) => new(statusCode, detail);
        protected Expression<Func<TEntity, object>>[] UpdatingProps<TEntity>(params Expression<Func<TEntity, object>>[] expressions) => expressions;
    }
}
