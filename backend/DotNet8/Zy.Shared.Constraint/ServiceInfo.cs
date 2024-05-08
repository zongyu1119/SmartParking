using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Zy.Shared.Constraint
{
    public class ServiceInfo
    {
        private static ServiceInfo _instance = null;
        private static readonly object _lockObj = new();

        public string Id { get; private set; }
        public string ServiceName { get; private set; }
        public string CorsPolicy { get; private set; }
        public string ShortName { get; private set; }
        public string Version { get; private set; }
        public string Description { get; private set; }

        public string EnvName {  get; private set; }
        /// <summary>
        /// 请求Path开始
        /// </summary>
        public string PathStart { get; private set; }
        public Assembly StartAssembly { get; private set; }

        private ServiceInfo()
        {
        }

        public static ServiceInfo CreateInstance(Assembly startAssembly)
        {
            if (_instance is not null)
                return _instance;

            lock (_lockObj)
            {
                if (_instance is not null)
                    return _instance;

                startAssembly ??= Assembly.GetEntryAssembly();

                var description = startAssembly.GetCustomAttribute<AssemblyDescriptionAttribute>().Description;
                var assemblyName = startAssembly.GetName();
                var version = assemblyName.Version;
                var fullName = assemblyName.Name.ToLower();
                var serviceName = fullName.Replace(".", "-");
                var ticks = (long)DateTime.Now.Ticks;
                var ticksHex = Convert.ToString(ticks, 16);
                var envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")?.ToLower();
                var serviceId = envName switch
                {
                    "development" => $"{serviceName}-dev-{ticksHex}",
                    "test" => $"{serviceName}-test-{ticksHex}",
                    "staging" => $"{serviceName}-stag-{ticksHex}",
                    "production" => $"{serviceName}-{ticksHex}",
                    "uat"=>$"{serviceName}-{ticksHex}",
                    _ => throw new NullReferenceException("ASPNETCORE_ENVIRONMENT")
                };

                _instance = new ServiceInfo
                {
                    Id = serviceId,
                    ServiceName = serviceName,
                    ShortName = fullName.Split(".")[1],
                    PathStart = $"/{fullName.Split(".")[1].ToLower()}",
                    CorsPolicy = "default",
                    StartAssembly = startAssembly,
                    Description = description,
                    Version = $"{version.Major}.{version.Minor}.{version.Build}.{version.Revision}",
                    EnvName = envName,
                };
            }
            return _instance;
        }

        public static ServiceInfo GetInstance()
        {
            if (_instance is null)
                throw new NullReferenceException(nameof(ServiceInfo));

            return _instance;
        }
    }
}
