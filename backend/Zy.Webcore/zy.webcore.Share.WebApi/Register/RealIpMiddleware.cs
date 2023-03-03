using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using zy.webcore.Share.Extensions;

namespace zy.webcore.Share.WebApi.Register
{
    /// <summary>
    /// 真实IP地址
    /// </summary>
    public class RealIpMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RealIpMiddleware> _logger;
        private readonly FilterOption _option;

        public RealIpMiddleware(RequestDelegate next, ILogger<RealIpMiddleware> logger, FilterOption option)
        {
            _next = next;
            _logger = logger;
            _option = option;
        }

        public async Task Invoke(HttpContext context)
        {
            if (_option.HeaderKey.IsNullOrWhiteSpace())
            {
                await _next(context);
                return;
            }

            var ips = context.Request.Headers[_option.HeaderKey].FirstOrDefault()?.Trim();
            if (ips.IsNullOrEmpty())
            {
                await _next(context);
                return;
            }
            var realIp = ips.Split(",")[0];
            if (realIp == string.Empty)
            {
                await _next(context);
                return;
            }
            context.Connection.RemoteIpAddress = IPAddress.Parse(realIp);
            _logger.LogDebug($"Resolve real ip success: {context.Connection.RemoteIpAddress}");

            await _next(context);
        }
    }

    public class FilterOption
    {
        public string HeaderKey { get; set; }
    }
    /// <summary>
    /// 扩展
    /// </summary>
    public static class RealIpMiddlewareExtensions
    {
        /// <summary>
        /// 添加真实IP中间件
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="configureOption"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseRealIp(this IApplicationBuilder builder, Action<FilterOption> configureOption = null)
        {
            var option = new FilterOption();
            configureOption?.Invoke(option);
            return builder.UseMiddleware<RealIpMiddleware>(option);
        }
    }
}