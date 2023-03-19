using Nacos.V2.DependencyInjection;

namespace zy.webcore.Share.Nacos.Register
{
    public static class WebApplicationBuilderExtension
    {
        public static WebApplicationBuilder AddNacos(this WebApplicationBuilder builder, IServiceInfo serviceInfo)
        {
            //builder.WebHost.UseKestrel();
            // 注册服务到Nacos
            builder.Services.AddNacosAspNet(builder.Configuration, "NacosConfig"); //默认节点Nacos
            //builder.Services.AddNacosAspNet(config =>
            //{
            //    config = builder.Configuration.GetSection("NacosConfig").Get<NacosAspNetOptions>();
            //});
            builder.Services.AddNacos();
            // 添加配置中心
            builder.Host.ConfigureAppConfiguration((context, b) =>
            {
                b.AddNacosV2Configuration(builder.Configuration.GetSection("NacosConfig"));
            });
            return builder;
        }
    }
}
