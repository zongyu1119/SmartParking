using System.Net;

namespace Zy.Shared.Constraint.Dtos
{
    /// <summary>
    /// 返回
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ZyResult<T>:ZyResult
    {
        public ZyResult(T data) {
            if (data != null)
            {
                this.IsSuccessed = true;
                this.Data = data;
            }
            else
            {
                this.IsSuccessed= false;
                this.Message = "无数据返回！";
            }

            StatusCode = HttpStatusCode.OK;
        }

        public ZyResult(string? message) : base(message)
        {
        }

        public T? Data { get; set; }
       
    }
    public class ZyResult
    {
        public ZyResult(string? message)
        {
            IsSuccessed = false;
            StatusCode = HttpStatusCode.BadRequest;
            Message = message;
        }
        public ZyResult()
        {
            IsSuccessed = true;
            StatusCode = HttpStatusCode.OK;
        }
        public ZyResult(HttpStatusCode statusCode, string message)
        {
            StatusCode = statusCode; Message = message;
            if (statusCode != HttpStatusCode.OK) { IsSuccessed = true; }
            else { IsSuccessed = false; }
        }
        public bool IsSuccessed { get; set; }
        public string? Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
