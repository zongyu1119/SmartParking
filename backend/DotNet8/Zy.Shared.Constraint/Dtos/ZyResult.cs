using System.Net;

namespace Zy.Shared.Constraint.Dtos
{
    /// <summary>
    /// 返回
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ZyResult<T>:ZyResult
    {
        public ZyResult(T data)
        {
            Data = data;
        }
        public ZyResult(HttpStatusCode statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }
        public T? Data { get; set; }
        public string? Message { get; set; }
        public bool IsSuccess => StatusCode == HttpStatusCode.OK;
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
        public static implicit operator ZyResult<T>(T value) => new(value);
    }

    public class ZyResult
    {
        public ZyResult(HttpStatusCode statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }
        public ZyResult() { }
        public string? Message { get; set; }
        public bool IsSuccess => StatusCode == HttpStatusCode.OK;

        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
    }

}