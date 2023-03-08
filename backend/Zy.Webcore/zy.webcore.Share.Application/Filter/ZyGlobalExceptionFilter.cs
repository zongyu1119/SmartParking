using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using zy.webcore.Share.Application.Utilitys;

namespace zy.webcore.Share.Application.Filter
{
    public class ZyGlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<ZyGlobalExceptionFilter> _logger;
        public ZyGlobalExceptionFilter()
        {
            _logger = ServiceLocator.Instance.GetService<ILogger<ZyGlobalExceptionFilter>>();
        }
        public void OnException(ExceptionContext context)
        {
            context.Result=new Result
            _logger.LogError("[Error]" + context.Exception.Message ?? "");
        }
    }
}
