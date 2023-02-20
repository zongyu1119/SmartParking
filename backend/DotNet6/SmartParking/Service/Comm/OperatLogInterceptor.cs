﻿using Castle.DynamicProxy;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
///  Namespace: Service.Comm
///  Name： ServiceInterceptor
///  Author: zy
///  Time:  2022-04-06 23:00:35
///  Version:  0.1
/// </summary>

namespace SmartParking.Service.Comm
{
    /// <summary>
    /// 拦截器
    /// </summary>
    public class OperatLogInterceptor : IInterceptor
    {
        protected ILogger<OperatLogInterceptor> logger;//日志
        public OperatLogInterceptor(ILogger<OperatLogInterceptor> _logger)
        {
            logger = _logger;
        }
        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
                logger.LogInformation(invocation.Method.Name);
            }
            catch (Exception ex)
            {
                logger.LogInformation(invocation.Method.Name + " " + ex.ToString());
            }
        }
    }
}
