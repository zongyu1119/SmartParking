using Autofac.Extras.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
///  Namespace: Service.IService
///  Name： IAuditService
///  Author: zy
///  Time:  2022-04-13 22:26:30
///  Version:  0.1
/// </summary>

namespace Service.IService
{
    /// <summary>
    /// 审计相关Service
    /// </summary>
    [Intercept(typeof(Comm.ServiceInterceptor))]
    public interface IAuditService
    {
    }
}
