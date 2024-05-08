using Microsoft.Extensions.DependencyInjection;
using SkyApm.Utilities.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zy.Shared.Constraint;

namespace Zy.Shared.SkyApm.Register
{
    public static class RegisterSkyApm
    { 
        /// <summary>
        /// 注册SkyApm
        /// </summary>
        /// <param name="services"></param>
        /// <param name="serviceInfo"></param>
        /// <returns></returns>
        public static IServiceCollection AddSkyApm(this IServiceCollection services, ServiceInfo serviceInfo)
        {
            SetSkyApmEnv(serviceInfo);
            services.AddSkyApmExtensions();
            return services;
        }
        private static void SetSkyApmEnv(ServiceInfo serviceInfo)
        {
            Environment.SetEnvironmentVariable("ASPNETCORE_HOSTINGSTARTUPASSEMBLIES", "SkyAPM.Agent.AspNetCore");
            Environment.SetEnvironmentVariable("SKYWALKING__SERVICENAME", serviceInfo.ShortName);
        }
    }
}
