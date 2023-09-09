using DotNetCore.CAP.Filter;
using Microsoft.Extensions.Logging;

namespace zy.webcore.Share.Application.Filter;

/// <summary>
/// https://cap.dotnetcore.xyz/user-guide/zh/cap/filter/
/// </summary>
public sealed class ZyCapFilter : SubscribeFilter
{
    private readonly ILogger<ZyCapFilter> _logger;
    public ZyCapFilter(ILogger<ZyCapFilter> logger)
    {
        _logger = logger;
    }

    public override Task OnSubscribeExecutingAsync(ExecutingContext context)
    {
        return Task.CompletedTask;
    }

    public override Task OnSubscribeExecutedAsync(ExecutedContext context)
    {
        return Task.CompletedTask;
    }
    /// <summary>
    /// 出错时的处理
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public override Task OnSubscribeExceptionAsync(DotNetCore.CAP.Filter.ExceptionContext context)
    {
        _logger.LogError(context.Exception, context.Exception.Message);
        return Task.CompletedTask;
    }
}
