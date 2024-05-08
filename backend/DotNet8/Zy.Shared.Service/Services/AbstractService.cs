using System.Net;
using Zy.Shared.Constraint.Dtos;

namespace Zy.Shared.Service.Services
{
    public  class AbstractService
    {
        public static ZyResult Result()
        {
            return new ZyResult();
        }
        public static ZyResult<T> Result<T>(T data)
        {
            return new ZyResult<T>(data);
        }
        public static ZyResult Problem(HttpStatusCode statusCode, string message)
        {
            return new ZyResult(statusCode, message);
        }
    }
}
