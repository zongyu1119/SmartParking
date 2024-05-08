using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nacos.AspNetCore.V2;
using Nacos.V2;
using Nacos.V2.Naming.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zy.Shared.Nacos.Register
{
    public static class RegisterNacos
    {
        public static WebApplicationBuilder AddNacos(this WebApplicationBuilder builder)
        {
            //builder.WebHost.UseKestrel();
            builder.Services.AddSingleton(typeof(IEventListener), typeof(NacosListener));
            
            // 注册服务到Nacos
            builder.Services.AddNacosAspNet(builder.Configuration, "NacosConfig"); //默认节点Nacos
            // 添加配置中心
            builder.Configuration.AddNacosV2Configuration(builder.Configuration.GetSection("NacosConfig"));
            //builder.WebHost.UseKestrel();
            return builder;
        }
    }
}
