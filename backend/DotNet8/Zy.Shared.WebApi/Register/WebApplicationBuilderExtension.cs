using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zy.Shared.Nacos.Register;
using AspectCore.Extensions.DependencyInjection;
using Zy.Shared.Constraint;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NLog.Extensions.Logging;
using Google.Protobuf.WellKnownTypes;
using Zy.Shared.ServicesLocator;

namespace Zy.Shared.WebApi.Register
{
    public static class WebApplicationBuilderExtension
    {
        public static WebApplicationBuilder BuildZyShared(this WebApplicationBuilder builder,ServiceInfo serviceInfo)
        {
            if (builder.Configuration["config"] == "nacos")
                builder.AddNacos();
            builder.Logging.AddNLog("Configs/NLog.config");
            builder.Services.AddSingleton(typeof(IConfiguration), builder.Configuration);
            builder.Services.AddZySharedService(serviceInfo, builder.Configuration);
            builder.Host.UseServiceProviderFactory(new DynamicProxyServiceProviderFactory());
           
            return builder;
        }
    }
}
