using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace zy.webcore.Share.Constraint.Dtos.ResultModels
{
    public class AppSrvResult<T> where T : class
    {
        public AppSrvResult(T? data)
        {
            Data = data;
        }
        public AppSrvResult(HttpStatusCode statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }
        public AppSrvResult(string message)
        {
            StatusCode = HttpStatusCode.BadRequest;
            Message = message;
        }
        public T? Data { get; set; }
        public string? Message { get; set; }
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
        public static implicit operator AppSrvResult<T>(T value) => new(value);
        public static implicit operator AppSrvResult<T>(string message) => new(message);
    }
    public class AppSrvResult
    {
        public AppSrvResult(HttpStatusCode statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }
        public AppSrvResult(string message) { StatusCode = HttpStatusCode.BadRequest; Message = message; }
        public AppSrvResult() { }
        public string? Message { get; set; }
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
        public static implicit operator AppSrvResult(string message) => new(message);
    }
}
